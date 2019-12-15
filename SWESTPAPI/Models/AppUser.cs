using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWESTPAPI.Models
{
    public class AppUser
    {
        [Key]
        [Required]
        public String Email { get; set; }

        [Required]
        public String ID { get; set; }
    
    
        [Required]
        public String Password { get; set; }

        public String Role { get; set; }

        public String VCode { get; set; }

        public String isVerified { get; set; }




        public Profile Profile { get; set; }

        public IList<MyTask>  myTasks { get; set; }
        public IList<UserCourse> userCourses { get; set; }

    
    }
}
