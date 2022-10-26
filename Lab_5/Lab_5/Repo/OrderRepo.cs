using Lab_5.DB;
using Lab_5.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_5.Repo
{
    public class OrderRepo
    {
        public List<OrderModel> Get()
        {
            return null;
        }

        public OrderModel Get(int Id)
        {
            return null;
        }

        public static int Create(OrderModel item)
        {
            var db = new Entities();
            var order = new Order()
            {
                OrderDate = item.OrderDate,
                Status = item.Status,
                OrderBy = item.OrderBy,
                TotalSum = item.TotalSum,
            };

            db.Orders.Add(order);
            if(db.SaveChanges() > 0)
            {
                return order.Id;
            }
            else
            {
                return 0;
            }
        }
    }
}