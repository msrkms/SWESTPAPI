using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWESTPAPI.Models
{
    public class ExamRoutine
    {
        [Key]
        public int id { get; set; }
    
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    
        public String CourseCode { get; set; }
        public Course Course { get; set; }

        public int SlotID { get; set; }

        public Slot Slot { get; set; }
    }
}
