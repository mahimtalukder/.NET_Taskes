using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class AreaModel
    {
        public int Id { get; set; }
        [Required]
        [UniqueArea]
        public string AreaName { get; set; }
    }

  
}