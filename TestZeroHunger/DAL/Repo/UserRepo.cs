using DAL.DB;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class UserRepo : IRepo<User, string>
    {
        public void Add(User obj)
        {
            throw new NotImplementedException();
        }

        public User Get(string Id)
        {
            var db = new TestZeroHungerEntities();
            var user = (from us in db.Users 
                        where us.UserName == Id select us).SingleOrDefault();
            return user;
        }
    }
}
