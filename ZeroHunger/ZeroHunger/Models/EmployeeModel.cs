using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime DOB { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public int AreaId { get; set; }
        public int UserId { get; set; }
    }
}