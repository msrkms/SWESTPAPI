using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWESTPAPI.Models
{
    public class Course
    {
        [Key]
        public String CourseCode { get; set; }

        [Required]
        public String Title { get; set; }

        public List<CourseOffer> CourseOffer { get; set; }

        public IList<UserCourse> userCourses { get; set; }
    }
}
