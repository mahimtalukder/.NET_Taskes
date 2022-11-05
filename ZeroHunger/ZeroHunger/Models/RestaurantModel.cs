using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class RestaurantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public int AreaId { get; set; }
        public int UserId { get; set; }
    }
}