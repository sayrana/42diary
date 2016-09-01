using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configuration = DAL.Migrations.Configuration;

namespace DAL
{
    public class DatabaseInitializer : MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>
    {
    }
}
