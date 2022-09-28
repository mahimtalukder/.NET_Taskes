using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_2.Models
{
    public class User
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Special character not allowed")]
        [MaxLength(35, ErrorMessage = "Maximum length 35")]
        [MinLength(3, ErrorMessage = "Minimum length 3")]
        public string Name { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; } 

        public string DOB { get; set; }

        public string Blood_group { get; set; }

        public string Gender { get; set; }

        public string Password { get; set; }

        public string Confirm_password { get; set; }

    }
}