using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.EF.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DeptId { get; set; }
        public virtual Department Department { get; set; }


    }
}