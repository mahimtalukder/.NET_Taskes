using Lab_4_association.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_4_association.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var db = new UMS_DBEntities();
            var students = db.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            var db = new UMS_DBEntities();
            var st = db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var db = new UMS_DBEntities();
            var st = db.Students.Find(Id);
            return View(st);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            var db = new UMS_DBEntities();
            db.Students.AddOrUpdate(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int Id)
        {
            var db = new UMS_DBEntities();
            var st = db.Students.Find(Id);
            return View(st);
        }

        public ActionResult Delete(int Id)
        {
            var db = new UMS_DBEntities();
            var st = db.Students.Find(Id);
            db.Students.Remove(st);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}