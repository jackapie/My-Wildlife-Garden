using MyGardenWildlife2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGardenWildlife2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Birds()
        {
            var birdsData = DatabaseHelper.GetSection("Birds");

            return View(birdsData);
        }

        public ActionResult Inverts()
        {
            var invertsData = DatabaseHelper.GetSection("Invertebrates");


            return View(invertsData);
        }



        public ActionResult Mammals()
        {
            var mammalsData = DatabaseHelper.GetSection("Mammals, Amphibians and Reptiles");
            return View(mammalsData);
        }

        public ActionResult Plants()
        {
            var plantsData = DatabaseHelper.GetSection("Plants");
            return View(plantsData);
        }
    }
}