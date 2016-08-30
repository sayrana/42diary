using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private DatabaseContext context;

        private IDbSet<T> entities;

        public GenericRepository(DatabaseContext _context)
        {
            context = _context;
        }

        public void Add(T entity)
        {
            Entities.Add(entity);
        }

        public void Update(T entity)
        {
            var record = Entities.Find(entity);
            if (record != null)
            {
                record = entity;
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            if (entity != null)
            {
                Entities.Remove(entity);
            }
        }

        public T GetById(int id)
        {
            return Entities.Find(id);
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            return predicate == null
                ? Entities.FirstOrDefault()
                : Entities.FirstOrDefault(predicate);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null
                ? Entities
                : Entities.Where(predicate);
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = context.Set<T>();
                }
                return entities;
            }
        }
    }
}
