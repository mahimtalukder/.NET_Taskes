using DAL.EF.Models;
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
        public static IRepo<Post,int,Post> PostDataAccess()
        {
            return new PostRepo();
        }
    }
}
