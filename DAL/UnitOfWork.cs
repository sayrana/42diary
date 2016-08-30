using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;

namespace DAL
{
        public class UnitOfWork : IDisposable
        {
            private readonly DatabaseContext context;
            private bool disposed;
            private Dictionary<string, object> repositories;

            public UnitOfWork(DatabaseContext _context)
            {
                context = _context;
            }

            public UnitOfWork()
            {
                context = new DatabaseContext();
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            public void Save()
            {
                context.SaveChanges();
            }

            public virtual void Dispose(bool disposing)
            {
                if (!disposed)
                {
                    if (disposing)
                    {
                        context.Dispose();
                    }
                }
                disposed = true;
            }

            public GenericRepository<T> Repository<T>() where T : class
            {
                if (repositories == null)
                {
                    repositories = new Dictionary<string, object>();
                }

                var type = typeof(T).Name;

                if (!repositories.ContainsKey(type))
                {
                    var repositoryType = typeof(GenericRepository<>);
                    var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
                    repositories.Add(type, repositoryInstance);
                }
                return (GenericRepository<T>)repositories[type];
            }
        }
}
