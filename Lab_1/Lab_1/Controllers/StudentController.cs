using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var age = 20;
            dynamic name = "Mahim";
            ViewBag.name = name;
            ViewData["age"] = age;
            return View();
        }

        public ActionResult Project()
        {
            //return Redirect("");
            return RedirectToAction("About", "Home");
        }
    }
}