using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class CartItem
    {
        public int id { get; set; }

        public Car car { get; set; }

        public int price { get; set; }

        public string CartId { get; set; }
    }
}
