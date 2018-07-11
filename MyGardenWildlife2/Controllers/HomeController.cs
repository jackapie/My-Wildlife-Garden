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

      
        public ActionResult BirdsOld()
        {

            return View();
        }

        public ActionResult Birds()
        {
            var birdsData = DatabaseHelper.GetBirdsData();

            return View(birdsData);
        }

        public ActionResult InvertsOld()
        {
            var invertsData = DataHelperClass.GetInvertsData(); 

            return View(invertsData);
        }

        public ActionResult Inverts()
        {
            var invertsData = DatabaseHelper.GetInvertsData();


            return View(invertsData);
        }



        public ActionResult Mammals()
        {
            var mammalsData = DatabaseHelper.GetMammalsData();
            return View(mammalsData);
        }

        public ActionResult Plants()
        {

            return View();
        }
    }
}