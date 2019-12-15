using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWESTPAPI.Models
{
    public class ClassRoutine
    {
        [Key]
        public int id { get; set; }


        public string Section { get; set; }


        public string Day { get; set; }

        public string TeacherInitial { get; set; }

        public string RoomNo { get; set; }


        public string CourseCode { get; set; }

        public Course Course { get; set; }


        public int SlotID { get; set; }
        public Slot Slot { get; set; }

    }
}
