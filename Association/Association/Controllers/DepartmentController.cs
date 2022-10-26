using Association.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Association.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            var db = new UMSEntities();
            var departments = db.Departments.ToList();
            return View(departments);
        }

        public ActionResult Details(int Id)
        {
            var db = new UMSEntities();
            var department = (from dpartment in db.Departments.Include("Students")
                             where dpartment.Id == Id
                             select dpartment).SingleOrDefault();
            return View(department);
        }
    }
}