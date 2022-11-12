using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class DistributeRequestModel
    {

        public int Id { get; set; }
        public int Status { get; set; }
        [Required]
        public System.DateTime PreserveTill { get; set; }
        public int RestaurantId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public int AreaId { get; set; }
    }
}