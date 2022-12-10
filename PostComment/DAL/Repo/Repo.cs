using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class Repo
    {
        protected PostContext db;
        internal Repo()
        {
            db = new PostContext();
        }
    }
}
