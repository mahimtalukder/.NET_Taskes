using DAL.EF.Models;
using DAL.Interfaces;
using DAL.IRepo;
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
        public static IRepo<User, int, User> UserDataAccess()
        {
            return new UserRepo();
        }
        public static IAuth AuthDataAccess()
        {
            return new UserRepo();
        }
        public static IRepo<Token, string, Token> TokenDataAccess()
        {
            return new TokenRepo();
        }
    }
}
