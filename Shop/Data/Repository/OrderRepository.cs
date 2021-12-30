using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly Cart cart;


        public OrderRepository(AppDBContent appDBContent, Cart cart)
        {
            this.appDBContent = appDBContent;
            this.cart = cart;
        }


        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = cart.listItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail
                {
                    CarId = el.car.id,
                    orderId = order.id,
                    price = el.car.price
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }

            appDBContent.SaveChanges();
        }
    }
}
