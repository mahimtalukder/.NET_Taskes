using Lab_3.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Lab_3.Controllers
{
    public class EcommerceController : Controller
    {
        // GET: Ecommerce
        public ActionResult Index()
        {
            var db = new EcommerceEntities1();
            var products = db.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            var db = new EcommerceEntities1();
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult EditProduct(int Id)
        {
            var db = new EcommerceEntities1();
            var product = (from b in db.Products
                        where b.Id == Id
                        select b).SingleOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            var db = new EcommerceEntities1();
            var ext = (from b in db.Products
                       where b.Id == product.Id
                       select b).SingleOrDefault();


            db.Entry(ext).CurrentValues.SetValues(product);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int Id)
        {
            var db = new EcommerceEntities1();
            var product = db.Products.Find(Id);

            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Products()
        {
            var db = new EcommerceEntities1();
            var products = db.Products.ToList();
            return View(products);
        }

        public ActionResult Cart()
        {
            string json = (string)Session["products"];
            if(json == null)
            {
                return View();
            }
            var products = new JavaScriptSerializer().Deserialize<List<Product>>(json);
            return View(products);
        }

        public ActionResult AddingCart(int Id)
        {
            var db = new EcommerceEntities1();
            var product = (from b in db.Products
                           where b.Id == Id
                           select b).SingleOrDefault();
            if (Session["products"] == null)
            {
                List<Product> products = new List<Product>();
                products.Add(product);
                string json = new JavaScriptSerializer().Serialize(products);
                Session["products"] = json;

            }
            else
            {
                string json = (string)Session["products"];
                var products = new JavaScriptSerializer().Deserialize<List<Product>>(json);
                products.Add(product);
                json = new JavaScriptSerializer().Serialize(products);
                Session["products"] = json;

            }
            return RedirectToAction("Cart");
        }

        public ActionResult Order()
        {
            var db = new EcommerceEntities1();
            var oder = db.Orders.ToList();
            return View(oder);

        }

        public ActionResult OrderDetails(int Id)
        {
            var db = new EcommerceEntities1();
            var oder_details = (from b in db.OrderDetails
                        where b.OrderId == Id
                        select b).ToList();
            return View(oder_details);

        }
        public ActionResult CheckOut()
        {
            var db = new EcommerceEntities1();
            string json = (string)Session["products"];
            var products = new JavaScriptSerializer().Deserialize<List<Product>>(json);
            double totle_price = 0.0;
            foreach(var product in products)
            {
                totle_price += product.Price;
            }
            var order = new Order()
            {
                Price = totle_price
            };
            db.Orders.Add(order);
            db.SaveChanges();
            foreach (var product in products)
            {
                var order_details = new OrderDetail()
                {
                    OrderId = order.Id,
                    ProductId = product.Id
                };
                db.OrderDetails.Add(order_details);
                db.SaveChanges();
            }
            Session.Remove("products");


            return RedirectToAction("Order", order.Id);
        }
    }
}