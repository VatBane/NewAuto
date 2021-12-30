using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly Cart _cart;

        public CartController(IAllCars carRep, Cart cart)
        {
            _carRep = carRep;
            _cart = cart;
        }

        public ViewResult Index()
        {
            var items = _cart.GetItems();
            _cart.listItems = items;

            var obj = new CartViewModel
            {
                cart = _cart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRep.Cars.FirstOrDefault(i => i.id == id);

            if (item != null)
            {
                _cart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }

    }
}
