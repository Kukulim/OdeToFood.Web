using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData database;

        public RestaurantsController(IRestaurantData database)
        {
            this.database = database;
        }
        // GET: Restaurants
        public ActionResult Index()
        {
            var model = database.GetAll();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = database.Get(id);
            if (model == null)
            {
                return View("Notfound");
            }
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                database.Add(restaurant);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var model = database.Get(id);
            if (model == null)
            {
                return View("Notfound");
            }
            return View(model);        
        }
        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                database.Edit(restaurant);
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }
    }
}