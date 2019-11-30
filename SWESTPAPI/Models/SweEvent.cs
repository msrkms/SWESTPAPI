using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWESTPAPI.Models
{
    public class SweEvent
    {
        [Key]
        public int ID { get; set; }


        public String Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime  Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public String Details { get; set; }

        public String AttachmentUrl { get; set; }

    }
}
