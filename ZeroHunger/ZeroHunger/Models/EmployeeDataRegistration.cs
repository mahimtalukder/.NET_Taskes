using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class EmployeeDataRegistration
    {
        public int UserId { get; set; }
        [Required]
        [CheckEmail]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        public System.DateTime DOB { get; set; }
        public string Image { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int AreaId { get; set; }
    }
}