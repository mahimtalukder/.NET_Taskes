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
    [RestaurantAccess]
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            string json = (string)Session["restaurant"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var restaurant = RestaurantRepo.Get(user.Id);
            return View(restaurant);
        }

        public ActionResult ViewProfile()
        {
            string json = (string)Session["restaurant"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var restaurant = RestaurantRepo.Get(user.Id);

            var area = AreaRepo.Get();
            ViewBag.Area = area;
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Setting()
        {
            string json = (string)Session["restaurant"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var restaurant = RestaurantRepo.Get(user.Id);

            var area = AreaRepo.Get();
            ViewBag.Area = area;
            return View(restaurant);
        }

        [HttpPost]
        public ActionResult Setting(RestaurantData restaurant)
        {
            string json = (string)Session["restaurant"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var old_restaurant = RestaurantRepo.Get(user.Id);
            var area = AreaRepo.Get();
            ViewBag.Area = area;
            if (ModelState.IsValid)
            {
                RestaurantRepo.Update(restaurant);
                return RedirectToAction("ViewProfile");

            }
            restaurant.Image = old_restaurant.Image;
            return View(restaurant);
        }
    }
}