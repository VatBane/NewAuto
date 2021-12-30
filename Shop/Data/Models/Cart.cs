using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Shop.Data.Models
{
    public class Cart
    {
        private readonly AppDBContent appDBContent;

        public Cart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string CartId { get; set; }

        public List<CartItem> listItems { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var content = services.GetService<AppDBContent>();
            string cartId = session.GetString("CardId") ?? Guid.NewGuid().ToString();

            session.SetString("CardId", cartId);

            return new Cart(content) { CartId = cartId };
        }

        public void AddToCart(Car car)
        {
            this.appDBContent.CartItem.Add(new CartItem
            {
                CartId = this.CartId,
                car = car,
                price = car.price
            });

            appDBContent.SaveChanges();
        }

        public List<CartItem> GetItems()
        {
            return appDBContent.CartItem.Where(c => c.CartId == CartId).Include(s => s.car).ToList();
        }
    }
}
