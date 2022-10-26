using Lab_5.DB;
using Lab_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_5.Repo
{
    public class CategoryRepo
    {
        public static List<CategoryModel> Get()
        {
            var categories = new List<CategoryModel>();
            var db = new Entities();

            foreach (var item in db.Categories)
            {
                categories.Add(new CategoryModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }

            return categories;
        }

        public static CategoryModel Get(int Id)
        {
            var db = new Entities();
            var category = new CategoryModel();
            var dpr = db.Categories.Find(Id);

            category.Id = dpr.Id;
            category.Name = dpr.Name;

            return category;

        }

        public static void Create(CategoryModel item)
        {

            var db = new Entities();
            db.Categories.Add(new Category()
            {
                Id =item.Id,
                Name=item.Name,

            });
            db.SaveChanges();


        }
    }

}