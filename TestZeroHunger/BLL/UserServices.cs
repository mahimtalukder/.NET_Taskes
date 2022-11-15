using BLL.Models;
using DAL.DB;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserServices
    {
        public static UserModel Login(string Id, string Password)
        {
            var repo = new UserRepo();
            var user = repo.Get(Id);
            if (user != null)
            {
                if (user.Password.Equals(Password))
                {
                    var gettedUser = new UserModel();
                    gettedUser.Password = user.Password;
                    gettedUser.Id = user.Id;
                    gettedUser.UserName = user.UserName;
                    gettedUser.Type = user.Type;
                    return gettedUser;
                }
                else
                {
                    return null;
                }
            }
            else { return null; }
        }
    }
}
