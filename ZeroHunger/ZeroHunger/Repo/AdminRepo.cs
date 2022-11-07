using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHunger.DB;
using ZeroHunger.Models;

namespace ZeroHunger.Repo
{
    public class AdminRepo
    {
        public static List<AdminModel> Get()
        {
            var admins = new List<AdminModel>();
            var db = new ZeroHungerEntities();

            foreach (var admin in db.Admins)
            {
                admins.Add(new AdminModel()
                {
                    Id = admin.Id,
                    Name = admin.Name,
                    Image = admin.Image,
                    Address = admin.Address,
                    UserId = admin.UserId,
                });
            }

            return admins;
        }

        public static AdminModel Get(int UserId)
        {
            var db = new ZeroHungerEntities();
            var admin = new AdminModel();
            var db_admin = (from ad in db.Admins
                            where ad.UserId == UserId
                            select ad).SingleOrDefault();

            admin.Id = db_admin.Id;
            admin.Name = db_admin.Name;
            admin.Image = db_admin.Image;
            admin.Address = db_admin.Address;
            admin.UserId = db_admin.UserId;

            return admin;

        }
    }
}