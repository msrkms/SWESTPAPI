using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWESTPAPI.Models
{
    public class Slot
    {
        [Key]
        public int id { get; set; }
    
        [DataType(DataType.Time)]
        public DateTime  StartTime { get; set; }


        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        public IList<ClassRoutine> classRoutines { get; set; }

        public IList<ExamRoutine> examRoutines { get; set; }
    }
}
