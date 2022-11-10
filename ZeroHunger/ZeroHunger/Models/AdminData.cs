using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class AdminData
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [CheckEmailAdmin]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public System.DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
    }
}