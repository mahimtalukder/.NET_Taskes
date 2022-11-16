using DAL.DB;
using DAL.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class CategoryRepo : IRepo<Category, int>
    {
        public void Create(Category data)
        {
            var db = new NewsDBEntities();
            db.Categories.Add(data);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            var db = new NewsDBEntities();
            db.Categories.Remove(db.Categories.Find(Id));
            db.SaveChanges();
        }

        public List<Category> Get()
        {
            var db = new NewsDBEntities();
            var categories = db.Categories.ToList();
            return categories;
        }

        public Category Get(int Id)
        {
            var db = new NewsDBEntities();
            var category = db.Categories.SingleOrDefault(c => c.Id == Id);
            return category;

        }

        public Category Update(Category data)
        {
            var db = new NewsDBEntities();
            var category = db.Categories.SingleOrDefault(c => c.Id == data.Id);
            category.Name = data.Name;
            db.SaveChanges();
            return category;
        }
    }
}
