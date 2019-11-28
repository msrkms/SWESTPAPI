using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SWESTPAPI.Models
{
    public class Profile
    {

        [Key]
        [Required]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public int Semester { get; set; }

        public string Section { get; set; }

        
        public String Email { get; set; }
        public AppUser AppUser { get; set; }
    }
}
