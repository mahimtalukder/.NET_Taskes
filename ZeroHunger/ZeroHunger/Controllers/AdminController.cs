using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ZeroHunger.DB;
using ZeroHunger.Models;
using ZeroHunger.Repo;

namespace ZeroHunger.Controllers
{
    [AdminAccess]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            string json = (string)Session["admin"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var admin = AdminRepo.Get(user.Id);
            return View(admin);
        }

        public ActionResult ViewProfile()
        {
            string json = (string)Session["admin"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var admin = AdminRepo.Get(user.Id);
            return View(admin);
        }

        [HttpGet]
        public ActionResult Setting()
        {
            string json = (string)Session["admin"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var admin = AdminRepo.Get(user.Id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult Setting(AdminData admin)
        {
            string json = (string)Session["admin"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var old_admin = AdminRepo.Get(user.Id);
            if (ModelState.IsValid)
            {
                AdminRepo.Update(admin);
                return RedirectToAction("ViewProfile");

            }
            admin.Image = old_admin.Image;
            return View(admin);
        }
    }
}