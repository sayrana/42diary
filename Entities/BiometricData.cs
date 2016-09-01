using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class BiometricInfo
    {
        [Key]
        public int Id { get; set; }
        public int HeartRate { get; set; }
        public DateTime Date { get; set; }

        public virtual BiometricMetadata Metadata { get; set; }
        public virtual User User { get; set; }
    }

    public class BiometricMetadata
    {
        [Key, ForeignKey("BiometricInfo")]
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Waist { get; set; }
        public double Hips { get; set; }

        public virtual BiometricInfo BiometricInfo { get; set; }
    }
}
