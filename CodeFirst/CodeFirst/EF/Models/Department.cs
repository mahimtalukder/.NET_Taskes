﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst.EF.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual List<Student> Students { get; set; }
        public virtual List<Course> Courses { get; set; }

        public Department()
        {
            Courses = new List<Course>();
            Students = new List<Student>();
        }


    }
}