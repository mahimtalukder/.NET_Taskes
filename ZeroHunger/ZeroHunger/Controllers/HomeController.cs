using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.DB;
using ZeroHunger.Models;
using ZeroHunger.Repo;

namespace ZeroHunger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            var areas = AreaRepo.Get();
            ViewBag.areas = areas;
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RestaurantData data)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel();
                user.Email = data.Email;
                user.Password = data.Password;
                user.Type = 3;

                var newUser = UserRepo.Create(user);

                var restaurent = new RestaurantModel();
                restaurent.Name = data.Name;
                restaurent.Image = "~/Assets/img/profiles/avatar-14.png";
                restaurent.Address = data.Address;
                restaurent.AreaId = data.AreaId;
                restaurent.UserId = newUser.Id;

                RestaurantRepo.Create(restaurent);
                return RedirectToAction("Login");
            }

            var areas = AreaRepo.Get();
            ViewBag.areas = areas;
            return View();
        }
    }
}