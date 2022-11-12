using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHunger.DB;
using ZeroHunger.Models;

namespace ZeroHunger.Repo
{
    public class DistributeRepo
    {
        public static List<DistributeRequestModel> Get()
        {
            var db = new ZeroHungerEntities();
            var requests = new List<DistributeRequestModel>();

            foreach (var item in db.DistributeRequests.ToList())
            {
                var request = new DistributeRequestModel();
                request.Id = item.Id;
                request.Status = item.Status;
                request.RestaurantId = item.RestaurantId;
                request.PreserveTill = item.PreserveTill;
                request.EmployeeId = item.EmployeeId;
                request.AreaId = item.AreaId;
                requests.Add(request);
            }

            return requests;
        }
        public static List<DistributeRequestModel> Get(int RestaurantId)
        {
            var db = new ZeroHungerEntities();
            var requests = new List<DistributeRequestModel>();

            foreach (var item in db.DistributeRequests.ToList())
            {
                if(item.RestaurantId == RestaurantId)
                {
                    var request = new DistributeRequestModel();
                    request.Id = item.Id;
                    request.Status =  item.Status;  
                    request.RestaurantId = item.RestaurantId;
                    request.PreserveTill = item.PreserveTill;
                    request.EmployeeId = item.EmployeeId;
                    requests.Add(request);
                }
            }

            return requests;

        }

        public static List<DistributeRequestModel> EmpGet(int EmployeeId)
        {
            var db = new ZeroHungerEntities();
            var requests = new List<DistributeRequestModel>();

            foreach (var item in db.DistributeRequests.ToList())
            {
                if (item.EmployeeId == EmployeeId)
                {
                    var request = new DistributeRequestModel();
                    request.Id = item.Id;
                    request.Status = item.Status;
                    request.RestaurantId = item.RestaurantId;
                    request.PreserveTill = item.PreserveTill;
                    request.EmployeeId = item.EmployeeId;
                    requests.Add(request);
                }
            }

            return requests;

        }

        public static DistributeRequest Create(DistributeRequestModel data)
        {
            var db = new ZeroHungerEntities();
            var request = new DistributeRequest()
            {
                PreserveTill = data.PreserveTill,
                Status = data.Status,
                RestaurantId = data.RestaurantId,
                AreaId = data.AreaId
            };
            db.DistributeRequests.Add(request);
            db.SaveChanges();

            return request;

        }

        public static void Update(DistributeRequestModel data)
        {
            var db = new ZeroHungerEntities();
            var request = (from rq in db.DistributeRequests
                           where rq.Id == data.Id 
                           select rq).SingleOrDefault();
            request.EmployeeId = data.EmployeeId;
            request.Status = 2;

            db.SaveChanges();
        }

        public static void UpdateStatus(DistributeRequestModel data)
        {
            var db = new ZeroHungerEntities();
            var request = (from rq in db.DistributeRequests
                           where rq.Id == data.Id && rq.EmployeeId == data.EmployeeId
                           select rq).SingleOrDefault();
           
            request.Status++;

            db.SaveChanges();
        }
    }
}