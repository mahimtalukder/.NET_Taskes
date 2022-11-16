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
    public class NewsServices
    {
        public static void Create(NewsModel data)
        {
            var obj = new NewsRepo();
            var news = new News()
            {
                Title = data.Title,
                CategoryId = data.CategoryId,
                Data = data.Data,
            };
            obj.Create(news);
        }

        public static List<NewsModel> Get()
        {
            var list = new List<NewsModel>();
            var obj = new NewsRepo();
            var newses = obj.Get();

            foreach (var news in newses)
            {
                var item = new NewsModel()
                {
                    Id = news.Id,
                    Title = news.Title,
                    CategoryId = news.CategoryId,
                    Data = news.Data,
                };
                list.Add(item);
            }

            return list;
        }

        public static NewsModel Get(int Id)
        {
            var obj = new NewsRepo();
            var news = obj.Get(Id);

            var mynews = new NewsModel()
            {
                Id = news.Id,
                Title = news.Title,
                CategoryId = news.CategoryId,
                Data = news.Data
            };

            return mynews;

        }

        public static void Update(NewsModel data)
        {
            var obj = new NewsRepo();
            var news = new News()
            {
                Id = data.Id,
                Title = data.Title,
                CategoryId = data.CategoryId,
                Data = data.Data
            };
            obj.Update(news);
        }

        public static void Delete(int Id)
        {
            var obj = new NewsRepo();
            obj.Delete(Id);
        }
    }
}
