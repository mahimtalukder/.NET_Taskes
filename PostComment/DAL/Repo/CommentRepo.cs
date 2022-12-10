using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CommentRepo : Repo, IRepo<Comment, int, Comment>
    {
        public Comment Add(Comment obj)
        {
            db.Comments.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;

        }

        public bool Delete(Comment obj)
        {
            throw new NotImplementedException();
        }

        public List<Comment> Get()
        {
            throw new NotImplementedException();
        }

        public Comment Get(int id)
        {
            throw new NotImplementedException();
        }

        public Comment Update(Comment obj)
        {
            throw new NotImplementedException();
        }
    }
}
