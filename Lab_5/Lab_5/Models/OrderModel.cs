using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_5.Models
{
    public class OrderModel
    {

        public int Id { get; set; }
        public string Status { get; set; }
        public double TotalSum { get; set; }
        public int OrderBy { get; set; }
        public System.DateTime OrderDate { get; set; }
    }
}