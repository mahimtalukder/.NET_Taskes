using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class DistributeDetailModel
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public int DistributeRequestId { get; set; }
    }
}