﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Interfaces;
using Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat)
        {
            _allCars = iAllCars;
            _allCategories = iCarsCat;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string curCategory = "";
            if (string.IsNullOrEmpty(category))
                cars = _allCars.Cars.OrderBy(i => i.id);
            else
            {
                if (string.Equals("petrol", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Бензин")).OrderBy(i => i.id);
                    curCategory = "Бензиновые";
                }
                else if (string.Equals("diesel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Дизель")).OrderBy(i => i.id);
                    curCategory = "Дизельные";
                }
                else if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Электро")).OrderBy(i => i.id);
                    curCategory = "Электромобили";
                } 
                else if (string.Equals("hybrid", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Гибрид")).OrderBy(i => i.id);
                    curCategory = "Гибридные";
                }
            }

            var carObj = new CarsListViewModel
            {
                allCars = cars,
                curCategory = curCategory
            };


            ViewBag.Title = "Страница с автомобилями";

            return View(carObj);
        }
    }
}
