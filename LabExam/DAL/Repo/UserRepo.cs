using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class UserRepo : Repo, IRepo<User, int, User>, IAuth
    {
        
        public User Add(User obj)
        {
           db.Users.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public User Authenticate(string uname, string pass)
        {
            var obj = db.Users.FirstOrDefault(x => x.Uname.Equals(uname) && x.Password.Equals(pass));
            return obj;
        }

        public bool Delete(int id)
        {
            var dbUser = Get(id);
            db.Users.Remove(dbUser);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public User Update(User obj)
        {
            var dbUser = Get(obj.Id);
            db.Entry(dbUser).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
