using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Lab_2.Models.DOBValidtion;

namespace Lab_2.Models
{
    public class User
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Special character not allowed")]
        [MaxLength(35, ErrorMessage = "Maximum length 35")]
        [MinLength(3, ErrorMessage = "Minimum length 3")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^([0-9][0-9])-([0-9]+)-([1-3])@student.aiub.edu", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required]
        //[RegularExpression(@"^([01]|+88)?\d{11}", ErrorMessage = "Only Bangladeshi number allowed.")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [DOBDateValidation]
        [Required]
        public DateTime DOB { get; set; }

        public string Blood_group { get; set; }

        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Minimum length of password is 8")]

        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter Password again")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Minimum length of confirm password is 8")]
        [Compare("Password", ErrorMessage = "Password not matching")]

        public string Confirm_password { get; set; }

    }
}