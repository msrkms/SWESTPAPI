using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWESTPAPI.Models
{
    public class CourseOfferSection
    {
        [Key]
        public int id { get; set; }


        public String Section;

        public int CourseOfferId { get; set; }

        public CourseOffer CourseOffer;
    }
}
