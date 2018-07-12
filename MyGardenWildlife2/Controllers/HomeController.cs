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

            return View();
        }
        public ActionResult InvertsOld()
        {
            var invertsData = DataHelperClass.GetInvertsData(); 

            return View(invertsData);
        }

        public ActionResult Inverts()
        {
            var invertsData = DatabaseHelper.GetSection("Invertebrates");


            return View(invertsData);
        }



        public ActionResult Mammals()
        {

            return View();
        }
        public ActionResult Plants()
        {

            return View();
        }
    }
}