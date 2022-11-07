using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHunger.DB;
using ZeroHunger.Models;

namespace ZeroHunger.Repo
{
    public class RestaurantRepo
    {
        public static List<RestaurantModel> Get()
        {
            var restaurants = new List<RestaurantModel>();
            var db = new ZeroHungerEntities();

            foreach (var restaurant in db.Restaurants)
            {
                restaurants.Add(new RestaurantModel()
                {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    Image = restaurant.Image,
                    Address = restaurant.Address,
                    AreaId = restaurant.AreaId,
                    UserId = restaurant.UserId,
                });
            }

            return restaurants;
        }

        public static RestaurantModel Get(int UserId)
        {
            var db = new ZeroHungerEntities();
            var user = new RestaurantModel();
            var res = (from rs in db.Restaurants
                       where rs.UserId == UserId
                       select rs).SingleOrDefault();

            user.Id = res.Id;
            user.Name = res.Name;
            user.Image = res.Image;
            user.Address = res.Address;
            user.AreaId = res.AreaId;
            user.UserId = res.UserId;

            return user;

        }

        public static void Create(RestaurantModel restaurant)
        {

            var db = new ZeroHungerEntities();
            var newUser = db.Restaurants.Add(new Restaurant()
            {
                Id = restaurant.Id,
                Name=restaurant.Name,
                Image=restaurant.Image,
                Address=restaurant.Address,
                AreaId=restaurant.AreaId,
                UserId=restaurant.UserId,

            });
            db.SaveChanges();


        }
    }
}