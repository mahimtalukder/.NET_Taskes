using Lab_5.DB;
using Lab_5.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Lab_5.Repo
{
    public class ProductRepo
    {
        public static List<ProductModel> Get()
        {
            var products = new List<ProductModel>();
            var db = new Entities();

            foreach(var item in db.Products)
            {
                products.Add(new ProductModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Qty = item.Qty,
                    CategoryId = item.CategoryId,
                });
            }

            return products;
        }

        public static ProductModel Get(int Id)
        {
            var db = new Entities();
            var product = new ProductModel();
            var dpr = db.Products.Find(Id);

            product.Id = dpr.Id;
            product.Name = dpr.Name;
            product.Price = dpr.Price;
            product.Qty = dpr.Qty;
            product.CategoryId = dpr.CategoryId;

            return product;

        }

        public static void Create(ProductModel item)
        {
            var product = new Product();
            product.Id = item.Id;
            product.Name = item.Name;
            product.Price = item.Price;
            product.Qty = item.Qty;
            product.CategoryId = item.CategoryId;
            var db = new Entities();
            db.Products.Add(product);
            db.SaveChanges();

        }
    }
}