using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BiometricInfo> BiometricInfo { get; set; }
    }
}
