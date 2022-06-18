using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Form_Validation.Models;
using System.ComponentModel.DataAnnotations;

namespace Form_Validation.Models
{
    public class student
    {
        [Required]
        [StringLength(50, ErrorMessage = "Please Insert a Name")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-\d{1}$", ErrorMessage = "Input Aiub Id format-- XX-XXXXX-X")]
        public string Id { get; set; }
        [Required]
        public string Dob { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}