using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BiometricInfo> BiometricInfos { get; set; }
        public DbSet<BiometricMetadata> BiometricMetadatas { get; set; }
        public DbSet<TrainingType> TrainingTypes { get; set; }
        public DbSet<Training> Trainins { get; set; }
        public DbSet<TrainingMetadata> TrainingMetadatas { get; set; }
        public DbSet<TrainingTemplate> Templates { get; set; }
    }
}
