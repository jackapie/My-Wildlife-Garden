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

        //Lists
        public ActionResult SectionList()
        {
            var dbHelper = new DatabaseHelper();
            var sections = dbHelper.GetSectionList();
            return View(sections);
        }

        public ActionResult CategoryList(int Id)
        {
            var dbHelper = new DatabaseHelper();
            var section = dbHelper.GetSectionById(Id);
            return View("CategoryList", section);

        }

        public ActionResult SpeciesList(int Id)
        {
            var dbHelper = new DatabaseHelper();
            var category = dbHelper.GetCategoryById(Id);
            return View("SpeciesList", category);
        }

        //Edits
        public ActionResult SectionEdit(int Id)
        {
            var dbHelper = new DatabaseHelper();
            var sectionData = dbHelper.GetSectionById(Id);
            return View("sectionEdit", sectionData);
        }

        public ActionResult CategoryEdit(int Id)
        {
            var dbHelper = new DatabaseHelper();
            var CategoryData = dbHelper.GetCategoryById(Id);
            return View("categoryEdit", CategoryData);
        }

        //Saves
        public ActionResult SectionSave(int SectionId, string SectionName, string SectionIntro)
        {
            var dbHelper = new DatabaseHelper();

            dbHelper.SetSection(SectionId, SectionName, SectionIntro);

            return RedirectToAction("SectionList");
        }

       

        public ActionResult CategorySave(int CategoryId, string CategoryName, int SectionId)
        {
            var dbHelper = new DatabaseHelper();
            dbHelper.SetCategory(CategoryId, CategoryName);
            return RedirectToAction("CategoryList", new { Id = SectionId});

        }

    }
}