using Lab_5.DB;
using Lab_5.Models;
using Lab_5.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI.HtmlControls;

namespace Lab_5.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View(ProductRepo.Get());
        }
        
        public ActionResult AddToCart(int Id)
        {
            var p = ProductRepo.Get(Id);
            p.Qty = 1;
            List<ProductModel> products = null;
            products = null;
            if (Session["cart"] == null)
            {
                products = new List<ProductModel>();
        

            }
            else
            {
                var json2 = Session["cart"].ToString();
                products = new JavaScriptSerializer().Deserialize<List<ProductModel>>(json2);
            }

            products.Add(p);
            var json = new JavaScriptSerializer().Serialize(products);
            Session["cart"] = json;
            TempData["Msg"] = "Product Added";
            return RedirectToAction("Index");
        }

        public ActionResult ShowCart()
        {
            if(Session["cart"] == null)
            {
                return RedirectToAction("Index");
            }
            var json2 = Session["cart"].ToString();
            var products = new JavaScriptSerializer().Deserialize<List<ProductModel>>(json2);
            return View(products);

        }
        [HttpPost]
        public ActionResult Checkout(double Total)
        {
            var order = new OrderModel();
            order.TotalSum = Total;
            order.OrderDate = DateTime.Now;
            order.Status = "ordered";
            order.OrderBy = 1;
            var orderId = OrderRepo.Create(order);
            if(orderId != 0)
            {
                var json2 = Session["cart"].ToString();
                var products = new JavaScriptSerializer().Deserialize<List<ProductModel>>(json2);
                foreach(var item in products)
                {
                    OrderDetailRepo.Create(new OrderDetailModel()
                    {
                        ProductId = item.Id,
                        Qty = item.Qty,
                        UnitPrice = item.Price,
                        OrderId = orderId,
                    });
                }
                Session["cart"] = null;

            }
            TempData["msg"] = "order pleed";
            return RedirectToAction("Index");

        }
    }
}