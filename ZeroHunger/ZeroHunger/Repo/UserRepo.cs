using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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

        public static UserModel Get(string Email, string Password, int Type)
        {
            var db = new ZeroHungerEntities();
            var user = new UserModel();
            var us = (from needUser in db.Users
                     where needUser.Email == Email && needUser.Type == Type
                     select needUser).SingleOrDefault();
            if(us != null)
            {
                if(us.Password == Password)
                {
                    user.Id = us.Id;
                    user.Email = us.Email;
                    user.Password = us.Password;
                    user.Type = us.Type;

                    return user;
                }
                else
                {
                    return null;
                }
            }
            return null;
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

        public static bool UniqueEmail(string email, int userID)
        {
            var db = new ZeroHungerEntities();
            var user = (from needUser in db.Users
                      where needUser.Id != userID && needUser.Email == email
                      select needUser).SingleOrDefault();

            if(user != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}