using DAL.DB;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class UserRepo : IRepo<User, string, User>, IAuth
    {
        BloodBankEntities db;
        internal UserRepo()
        {
            db = new BloodBankEntities();
        }
        public User Add(User obj)
        {
            db.Users.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public User Authenticate(string username, string password)
        {
            var user = db.Users.Find(username);
            if(user == null && user.Password == password)
            {
                return user;
            }
            return null;
        }

        public bool Delete(string id)
        {
            db.Users.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(string id)
        {
            return db.Users.Find(id);
        }

        public bool Update(User obj)
        {
            var ext = Get(obj.UserName);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;

        }
    }
}
