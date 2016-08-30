using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //context.Questions.Add(new QuestionInfo()
            //{
            //    Question = "question 1",
            //    Answer = "answer 1"
            //});
            //context.SaveChanges();
        }
    }
}
