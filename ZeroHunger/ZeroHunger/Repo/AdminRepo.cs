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

        public static AdminData Get(int UserId)
        {
            var db = new ZeroHungerEntities();
            var admin = new AdminData();
            var db_admin = (from ad in db.Admins
                            where ad.UserId == UserId
                            select ad).SingleOrDefault();
            var db_user = (from ad in db.Users
                           where ad.Id == UserId
                           select ad).SingleOrDefault();


            admin.Name = db_admin.Name;
            admin.Email = db_user.Email;
            admin.Password = db_user.Password;
            admin.Image = db_admin.Image;
            admin.DOB = db_admin.DOB;
            admin.Address = db_admin.Address;
            admin.UserId = db_admin.UserId;

            return admin;

        }

        public static string Update(AdminData admin)
        {
            var db = new ZeroHungerEntities();
            var db_admin = (from ad in db.Admins
                            where ad.UserId == admin.UserId
                            select ad).SingleOrDefault();
            var db_user = (from ad in db.Users
                           where ad.Id == admin.UserId
                           select ad).SingleOrDefault();
            db_user.Email = admin.Email;
            
            db_admin.Name = admin.Name;
            db_admin.Address = admin.Address;
            db_admin.DOB = admin.DOB;
            db.SaveChanges();

            return "updated";

        }
    }
}