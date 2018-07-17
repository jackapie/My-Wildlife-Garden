using MyGardenWildlife2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGardenWildlife2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SectionList()
        {
            var dbHelper = new DatabaseHelper();
            var sections = dbHelper.GetSectionList();
            return View(sections);
        }
    }
}