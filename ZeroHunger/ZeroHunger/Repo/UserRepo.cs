using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHunger.DB;
using ZeroHunger.Models;

namespace ZeroHunger.Repo
{
    public class UserRepo
    {
        public static List<UserModel> Get()
        {
            var users = new List<UserModel>();
            var db = new ZeroHungerEntities();

            foreach (var user in db.Users)
            {
                users.Add(new UserModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Password = user.Password,
                    Type = user.Type
                });
            }

            return users;
        }

        public static UserModel Get(int Id)
        {
            var db = new ZeroHungerEntities();
            var user = new UserModel();
            var us = db.Users.Find(Id);

            user.Id = us.Id;
            user.Email = us.Email;
            user.Password = us.Password;
            user.Type = us.Type;

            return user;

        }

        public static User Create(UserModel user)
        {

            var db = new ZeroHungerEntities();
            var newUser = db.Users.Add(new User()
            {
                Id = user.Id,
                Email = user.Email,
                Password= user.Password,
                Type= user.Type

            });
            db.SaveChanges();

            return newUser;

        }
    }
}