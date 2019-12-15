using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWESTPAPI.Models
{
    public class MyTask
    {
        [Key]
        public int id { get; set; }


        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String Details { get; set; }


        public String Email { get; set; }
        public AppUser AppUser { get; set; }

    }
}
