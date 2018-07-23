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

        public ActionResult SightingList(int Id)
        {
            var dbHelper = new DatabaseHelper();
            var species = dbHelper.GetSpeciesById(Id);
            return View(species);
        }

        public ActionResult FigureList(int Id)
        {
            var dbHelper = new DatabaseHelper();
            var sighting = dbHelper.GetSightingById(Id);
            return View(sighting);
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

        public ActionResult SpeciesEdit(int Id)
        {
            var dbHelper = new DatabaseHelper();
            var SpeciesData = dbHelper.GetSpeciesById(Id);
            return View(SpeciesData);
        }

        public ActionResult SightingEdit(int Id)
        {
            var dbHelper = new DatabaseHelper();
            var SightingData = dbHelper.GetSightingById(Id);
            return View(SightingData);
        }

        public ActionResult FigureEdit(int Id)
        {
            var dbHelper = new DatabaseHelper();
            var FigureData = dbHelper.GetFigureById(Id);
            return View(FigureData);
        }

        //Adds
        public ActionResult NewSection()
        {
            return View("NewSection");
        }


        public ActionResult SectionAdd(string SectionName, string SectionIntro)
        {
            var dbHelper = new DatabaseHelper();
            dbHelper.AddSection(SectionName, SectionIntro);
            return RedirectToAction("SectionList");
        }

        public ActionResult NewCategory(int Id)
        {
            return View(Id);
        }

        public ActionResult CategoryAdd(string CategoryName, int SectionId)
        {
            var dbHelper = new DatabaseHelper();
            dbHelper.AddCategory(CategoryName, SectionId);
            return RedirectToAction("CategoryList", new { Id = SectionId });
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

        public ActionResult SpeciesSave(int SpeciesId, int CategoryId, string CommonName, string LatinName)
        {
            var dbHelper = new DatabaseHelper();
            dbHelper.SetSpecies(SpeciesId, CommonName, LatinName);
            return RedirectToAction("SpeciesList", new { id = CategoryId });
        }

        public ActionResult SightingSave(int SightingId, int SpeciesId, DateTime When, string Where, int HowMany, string Comment)
        {
            var dbHelper = new DatabaseHelper();
            dbHelper.SetSighting(SightingId, When, Where, HowMany, Comment);
            return RedirectToAction("SightingList", new { id = SpeciesId });
        }

        public ActionResult FigureSave(int FigureId, int SightingId, string Source, string Alternative, string Caption)
        {
            var dbHelper = new DatabaseHelper();
            dbHelper.SetFigure(FigureId, Source, Alternative, Caption);
            return RedirectToAction("FigureList", new { id = SightingId });
        }
    }
}