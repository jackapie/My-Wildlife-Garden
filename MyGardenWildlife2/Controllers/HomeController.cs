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
        public ActionResult Section(int Id)
        {
            var dbHelper = new DatabaseHelper();
            var sectionData = dbHelper.GetSectionById(Id);

            return View("sectionView", sectionData);
        }


        public ActionResult Index()
        {
            return View();
        }



     
    }
}