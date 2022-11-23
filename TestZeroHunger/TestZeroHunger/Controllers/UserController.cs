using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestZeroHunger.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Id, string Password)
        {
            var user = UserServices.Login(Id, Password);
            if(user == null)
            {
                return View();

            }
            return RedirectToAction("Index", "Home");
        }
    }
}