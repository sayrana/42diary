using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TrainingType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Training> Trainings { get; set; }
    }

    public enum Intensity
    {
        Low,
        Medium,
        High
    }

    public class Training
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public virtual TrainingType Type { get; set; }
        public virtual TrainingMetadata Metadata { get; set; }
        public virtual TrainingTemplate Template { get; set; }
    }

    public class TrainingMetadata
    {
        [Key, ForeignKey("Training")]
        public int Id { get; set; }

        public double Distance { get; set; }
        public TimeSpan Time { get; set; }
        public Intensity Intensity { get; set; }

        public double AverageSpeed { get; set; }
        public double AverageTempo { get; set; }
        public double AverageHeartRate { get; set; }
        
        public virtual Training Training { get; set; }
}

    public class TrainingTemplate
    {
        [Key, ForeignKey("Training")]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Training Training { get; set; }
    }
}
