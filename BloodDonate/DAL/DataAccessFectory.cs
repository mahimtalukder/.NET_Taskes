using DAL.DB;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFectory
    {
        public static IRepo<Donor, int, bool> DonerDataAccess()
        {
            return new DonorRepo();
        }

        public static IRepo<Group, int, bool> GroupDataAccess()
        {
            return new GroupRepo();
        }

        public static IRepo<User, string, User> UserDataAccess()
        {
            return new UserRepo();
        }

        public static IAuth AuthDataAccess()
        {
            return new UserRepo();
        }
<<<<<<< HEAD
=======
        public static IRepo<Token, string, Token> TokenDataAccess()
        {
            return new TokenRepo();
        }
>>>>>>> 088bfe6b5482766e716d9d1e49288ca88534c0b8
    }
}
