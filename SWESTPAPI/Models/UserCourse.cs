using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWESTPAPI.Models
{
    public class UserCourse
    {
        [Key]
        public int id { get; set; }

        public string Section { get; set; }

        public string CourseCode { get; set; }
        public Course Course { get; set; }


        public string Email { get; set; }
        public AppUser AppUser { get; set; }

        

    }
}
