using Lab_4_association.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_4_association.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            var db = new UMS_DBEntities();
            var course = db.Courses.ToList();
            return View(course);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cours course)
        {
            var db = new UMS_DBEntities();
            var st = db.Courses.Add(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var db = new UMS_DBEntities();
            var st = db.Courses.Find(Id);
            return View(st);
        }

        [HttpPost]
        public ActionResult Edit(Cours course)
        {
            var db = new UMS_DBEntities();
            db.Courses.AddOrUpdate(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int Id)
        {
            var db = new UMS_DBEntities();
            var course = db.Courses.Find(Id);
            return View(course);
        }

        public ActionResult Delete(int Id)
        {
            var db = new UMS_DBEntities();
            var course = db.Courses.Find(Id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}