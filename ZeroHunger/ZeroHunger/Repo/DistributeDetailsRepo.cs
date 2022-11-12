using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHunger.DB;
using ZeroHunger.Models;

namespace ZeroHunger.Repo
{
    public class DistributeDetailsRepo
    {
        public static List<DistributeDetailModel> Get()
        {
            var db = new ZeroHungerEntities();
            var foods = new List<DistributeDetailModel>();

            foreach (var item in db.DistributeDetails.ToList())
            {

                var food = new DistributeDetailModel();
                food.Id = item.Id;
                food.FoodName = item.FoodName;
                food.DistributeRequestId = item.DistributeRequestId;
                foods.Add(food);
            }

            return foods;
        }
        public static List<DistributeDetailModel> Get(int DistributeRequestId)
        {
            var db = new ZeroHungerEntities();
            var foods = new List<DistributeDetailModel>();

            foreach(var item in db.DistributeDetails.ToList())
            {
                if(item.DistributeRequestId == DistributeRequestId)
                {
                    var food = new DistributeDetailModel();
                    food.Id = item.Id;
                    food.FoodName = item.FoodName;
                    food.DistributeRequestId = item.DistributeRequestId;
                    foods.Add(food);
                }
            }

            return foods;
        }
        public static void Create(List<DistributeDetailForCart> foods, int distributeRequestId)
        {
            var db = new ZeroHungerEntities();
            foreach (var item in foods)
            {
                var detais = new DistributeDetail()
                {
                    FoodName = item.FoodName,
                    DistributeRequestId = distributeRequestId
                };
                db.DistributeDetails.Add(detais);
            }
            db.SaveChanges();
        }
    }
}