using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Data.Services;


namespace OdeToFood.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly IRestaurantData RestaurantDb;

        public HomeController(IRestaurantData RestaurantDb)
        {
            this.RestaurantDb = RestaurantDb;
        }  
        public ActionResult Index()
        {
            var model = RestaurantDb.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}