using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWESTPAPI.Models
{
    public class CourseOffer
    {
        [Key]
        public int id { get; set; } 

        public int semester { get; set; }

        

        public String CourseCode { get; set; }

        public  Course Course { get; set; }

        public ExamRoutine ExamRoutine { get; set; }


        public IList<CourseOfferSection> courseOfferSections { get; set; }
    }
}
