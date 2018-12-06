using MyGardenWildlife3.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGardenWildlife3.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Section(int Id)
        {
            Models.SectionModel sectionData = GetSectionData(Id);

            return View("sectionView", sectionData);
        }

        private static Models.SectionModel GetSectionData(int Id)
        {
            var dbHelper = new DatabaseHelper();
            var sectionData = dbHelper.GetSectionById(Id);
            return sectionData;
        }

        public ActionResult HomePage()
        {
            return View("HomeScreen");
        }

        public ActionResult Index()
        {
            return View();
        }




    }
}