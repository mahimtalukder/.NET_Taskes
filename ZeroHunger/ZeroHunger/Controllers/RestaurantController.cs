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
            ViewBag.Restaurant = restaurant;

            var requests = DistributeRepo.Get(restaurant.Id);
            var foods = new List<List<DistributeDetailModel>>();

            foreach(var item in requests)
            {
               foods.Add(DistributeDetailsRepo.Get(item.Id));
            }
            ViewBag.Foods = foods;
            return View(requests);
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

        [HttpGet]
        public ActionResult DistributeRequests()
        {
            string json = (string)Session["restaurant"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var restaurant = RestaurantRepo.Get(user.Id);
            ViewBag.Restaurant = restaurant;
            if(Session["FoodDetail"] != null)
            {
                json = (string)Session["FoodDetail"];
                var foods = new JavaScriptSerializer().Deserialize<List<DistributeDetailForCart>>(json);
                ViewBag.FoodDetails = foods;
            }
            var model = new DistributeRequestModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult DistributeRequests(DistributeRequestModel request)
        {
            string json = (string)Session["restaurant"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var restaurant = RestaurantRepo.Get(user.Id);
            ViewBag.Restaurant = restaurant;

            json = (string)Session["FoodDetail"];
            var foods = new JavaScriptSerializer().Deserialize<List<DistributeDetailForCart>>(json);

            if (ModelState.IsValid)
            {
                request.Status = 1;
                request.RestaurantId = restaurant.Id;
                request.AreaId = restaurant.AreaId;
                var distributeRequest = DistributeRepo.Create(request);

                DistributeDetailsRepo.Create(foods, distributeRequest.Id);

                Session.Remove("FoodDetail");
                return RedirectToAction("Index");


            }
            else if (Session["FoodDetail"] != null)
            {
                ViewBag.FoodDetails = foods;
            }
            return View(request);
        }


        [HttpPost]
        public ActionResult AddToCart(DistributeDetailForCart detail)
        {
            if (detail.FoodName != null)
            {
                if (Session["FoodDetail"] == null)
                {
                    List<DistributeDetailForCart> foods = new List<DistributeDetailForCart>();
                    foods.Add(new DistributeDetailForCart()
                    {
                        Id = 1,
                        FoodName = detail.FoodName,
                    });
                    string json = new JavaScriptSerializer().Serialize(foods);
                    Session["FoodDetail"] = json;

                }
                else
                {
                    string json = (string)Session["FoodDetail"];
                    var foods = new JavaScriptSerializer().Deserialize<List<DistributeDetailForCart>>(json);
                    foods.Add(new DistributeDetailForCart()
                    {
                        Id = foods.Count + 1,
                        FoodName = detail.FoodName,
                    });
                    json = new JavaScriptSerializer().Serialize(foods);
                    Session["FoodDetail"] = json;
                }
            }

            return RedirectToAction("DistributeRequests");
        }

        public ActionResult RemoveFromCart(int Id)
        {
            string json = (string)Session["FoodDetail"];
            var foods = new JavaScriptSerializer().Deserialize<List<DistributeDetailForCart>>(json);
            for(int i = 0; i < foods.Count; i++)
            {
                if(foods[i].Id == Id)
                {
                    foods.RemoveAt(i);
                }
            }
            json = new JavaScriptSerializer().Serialize(foods);
            Session["FoodDetail"] = json;

            if(foods.Count == 0)
            {
                Session.Remove("FoodDetail");
            }
            return RedirectToAction("DistributeRequests");
        }

    }
}