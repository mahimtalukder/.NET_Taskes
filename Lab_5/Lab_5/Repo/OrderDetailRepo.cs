using Lab_5.DB;
using Lab_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_5.Repo
{
    public class OrderDetailRepo
    {
        public List<OrderDetailModel> Get()
        {
            return null;
        }

        public OrderDetailModel Get(int Id)
        {
            return null;
        }

        public static void Create(OrderDetailModel item)
        {
            var db = new Entities();
            db.OrderDetails.Add(new OrderDetail()
            {
                ProductId = item.ProductId,
                OrderId = item.OrderId,
                Qty = item.Qty,
                UnitPrice = item.UnitPrice,
            });
            db.SaveChanges();
        }
    }
}