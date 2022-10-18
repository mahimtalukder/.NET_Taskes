using Association.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Association.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        public ActionResult Index()
        {
            var db = new UMSEntities();
            return View(db.Courses.ToList());
        }

        [HttpPost]
        public ActionResult Index(int[] Courses)
        {
            var db = new UMSEntities();
            foreach (var Course in Courses)
            {
                db.CourseStudents.Add(new CourseStudent()
                {
                    CourseId = Course,
                    StudentId = 1
                });
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}