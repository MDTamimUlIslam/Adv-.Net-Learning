using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace First_Prokect.Models
{
    public class student
    {
        [Required (ErrorMessage = "Enter Your Name")]
        public double Name { get; set; }

        [Required(ErrorMessage = "Enter Your ID")]
        public double Id { get; set; }
        [Required(ErrorMessage = "Enter Your Dob")]
        public double Dob { get; set; }
        [Required(ErrorMessage = "Enter Your Email")]
        public double Email { get; set; }

        [Required(ErrorMessage = "Enter Your Gender")]
        public double Gender { get; set; }

        [Required(ErrorMessage = "Enter Your Dept")]
        public double Dept { get; set; }
    }
}