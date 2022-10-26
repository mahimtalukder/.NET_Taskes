using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_5.Models
{
    public class OrderDetailModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Qty { get; set; }
        public double UnitPrice { get; set; }
    }
}