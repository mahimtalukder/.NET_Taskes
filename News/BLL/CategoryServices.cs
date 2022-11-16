using BLL.Models;
using DAL.DB;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryServices
    {
        public static void Create(CategoryModel data)
        {
            var obj = new CategoryRepo();
            var category = new Category()
            {
                Name = data.Name,
            };
            obj.Create(category);
        }

        public static List<CategoryModel> Get()
        {
            var list = new List<CategoryModel>();
            var obj = new CategoryRepo();
            var categories = obj.Get();

            foreach(var category in categories)
            {
                var item = new CategoryModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                };
                list.Add(item);
            }

            return list;
        }

        public static CategoryModel Get(int Id)
        {
            var obj = new CategoryRepo();
            var cat = obj.Get(Id);

            var category = new CategoryModel()
            {
                Id = cat.Id,
                Name = cat.Name,
            };

            return category;

        }

        public static void Update(CategoryModel data)
        {
            var obj = new CategoryRepo();
            var cat = new Category()
            {
                Id = data.Id,
                Name = data.Name
            };
            obj.Update(cat);
        }

        public static void Delete(int Id)
        {
            var obj = new CategoryRepo();
            obj.Delete(Id);
        }
    }
}
