using DAL.DB;
using DAL.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class NewsRepo : IRepo<News, int>
    {
        public void Create(News data)
        {
            var db = new NewsDBEntities();
            db.Newses.Add(data);
            db.SaveChanges();
        }


        public void Delete(int Id)
        {
            var db = new NewsDBEntities();
            db.Newses.Remove(db.Newses.Find(Id));
            db.SaveChanges();
        }

        public List<News> Get()
        {
            var db = new NewsDBEntities();
            var newses = db.Newses.ToList();
            return newses;
        }

        public News Get(int Id)
        {
            var db = new NewsDBEntities();
            var news = db.Newses.SingleOrDefault(c => c.Id == Id);
            return news;
        }

        public News Update(News data)
        {
            var db = new NewsDBEntities();
            var news = db.Newses.SingleOrDefault(c => c.Id == data.Id);
            news.Title = data.Title;
            news.CategoryId = data.CategoryId;
            news.Data = data.Data;
            db.SaveChanges();
            return news;
        }
    }
}
