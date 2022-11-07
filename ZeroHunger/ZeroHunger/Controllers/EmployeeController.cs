using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ZeroHunger.DB;
using ZeroHunger.Repo;

namespace ZeroHunger.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            string json = (string)Session["employee"];
            if (json == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var admin = EmployeeRepo.Get(user.Id);
            return View(admin);
        }
    }
}