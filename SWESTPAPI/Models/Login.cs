using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWESTPAPI.Models
{
    public class Login
    {
        [Required]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }
    }
}
