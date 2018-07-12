﻿using MyGardenWildlife2.Helpers;
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
            var birdsData = DatabaseHelper.GetBirdsData();

            return View(birdsData);
        }

        public ActionResult Inverts()
        {
            var invertsData = DatabaseHelper.GetSection("Invertebrates");


            return View(invertsData);
        }



        public ActionResult Mammals()
        {
            var mammalsData = DatabaseHelper.GetMammalsData();
            return View(mammalsData);
        }

        public ActionResult Plants()
        {
            var plantsData = DatabaseHelper.GetPlantsData();
            return View(plantsData);
        }
    }
}