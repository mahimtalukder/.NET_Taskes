using Association.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Association.Controllers
{
    public class Department2Controller : Controller
    {
        // GET: Department2
        public ActionResult Index()
        {
            return View(DepartmentRepo.Get());
        }
    }
}