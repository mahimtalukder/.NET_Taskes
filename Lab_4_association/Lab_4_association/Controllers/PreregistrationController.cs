using Lab_4_association.DB;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_4_association.Controllers
{
    public class PreregistrationController : Controller
    {
        // GET: Preregistration
        [HttpGet]
        public ActionResult Index()
        {
            var db = new UMS_DBEntities();
            
            var courses = (from c in db.Courses
                           where (c.PreReq != null &&
                           c.PreReq == (from csg in db.CourseStudents
                                        where csg.CourseId == c.PreReq && csg.StudentId == 1 && csg.Grade != "W" && (csg.Status == "complete" || csg.Status == "Enrolled") && (csg.Grade == "A+" || csg.Grade == "D" || csg.Grade == "NaN")
                                        select csg.CourseId).FirstOrDefault()) || 
                            (c.PreReq == null && c.Id != (from csg in db.CourseStudents
                                                         where csg.StudentId == 1 && csg.CourseId == c.Id
                                                          select csg.CourseId).FirstOrDefault()) ||
                            (c.Id == (from csg in db.CourseStudents
                                      where csg.Status == "complete" && csg.StudentId == 1 && csg.CourseId == c.Id && (csg.Grade == "W" || csg.Marks < 60)
                                      select csg.CourseId).FirstOrDefault())
                           select c).ToList();            

            return View(courses);
        }

        [HttpPost]
        public ActionResult Index(int[] Courses)
        {
            var db = new UMS_DBEntities();
            foreach (var Course in Courses)
            {
                db.CourseStudents.Add(new CourseStudent()
                {
                   CourseId = Course,
                   StudentId = 1,
                   Status = "Enrolled",
                   Grade = "NaN",
                   Marks = 0.0
                });
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}