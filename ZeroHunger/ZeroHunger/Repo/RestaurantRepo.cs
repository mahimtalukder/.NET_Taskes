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

        public static RestaurantData Get(int UserId)
        {
            var db = new ZeroHungerEntities();
            var restaurant = new RestaurantData();
            var db_restaurant = (from ad in db.Restaurants
                               where ad.UserId == UserId
                               select ad).SingleOrDefault();
            var db_user = (from ad in db.Users
                           where ad.Id == UserId
                           select ad).SingleOrDefault();


            restaurant.Name = db_restaurant.Name;
            restaurant.Email = db_user.Email;
            restaurant.Password = db_user.Password;
            restaurant.Image = db_restaurant.Image;
            restaurant.Address = db_restaurant.Address;
            restaurant.UserId = UserId;
            restaurant.AreaId = db_restaurant.AreaId;

            return restaurant;

        }

        public static string Update(RestaurantData restaurant)
        {
            var db = new ZeroHungerEntities();
            var db_restaurant = (from res in db.Restaurants
                               where res.UserId == restaurant.UserId
                               select res).SingleOrDefault();
            var db_user = (from ad in db.Users
                           where ad.Id == restaurant.UserId
                           select ad).SingleOrDefault();

            db_user.Email = restaurant.Email;
            db_restaurant.Name = restaurant.Name;
            db_restaurant.Address = restaurant.Address;
            db_restaurant.AreaId = restaurant.AreaId;
            db.SaveChanges();

            return "updated";

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