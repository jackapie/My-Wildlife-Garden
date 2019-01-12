using MyGardenWildlife3.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGardenWildlife3.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        DatabaseHelper dbHelper = new DatabaseHelper();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //Lists
        public ActionResult SectionList()
        {

            var sections = dbHelper.GetSectionList();
            return View(sections);
        }

        public ActionResult CategoryList(int Id)
        {

            var section = dbHelper.GetSectionById(Id);
            return View(section);

        }

        public ActionResult SpeciesList(int Id)
        {

            var category = dbHelper.GetCategoryById(Id);
            return View(category);
        }

        public ActionResult SightingList(int Id)
        {

            var species = dbHelper.GetSpeciesById(Id);
            return View(species);
        }


        public ActionResult FigureList(int Id)
        {

            var sighting = dbHelper.GetSightingById(Id);
            return View(sighting);
        }

        //Edits
        public ActionResult SectionEdit(int Id)
        {

            var sectionData = dbHelper.GetSectionById(Id);
            return View(sectionData);
        }

        public ActionResult CategoryEdit(int Id)
        {

            var CategoryData = dbHelper.GetCategoryById(Id);
            return View(CategoryData);
        }

        public ActionResult SpeciesEdit(int Id)
        {

            var SpeciesData = dbHelper.GetSpeciesById(Id);
            return View(SpeciesData);
        }

        public ActionResult SightingEdit(int Id)
        {

            var SightingData = dbHelper.GetSightingById(Id);
            return View(SightingData);
        }

        public ActionResult FigureEdit(int Id)
        {

            var FigureData = dbHelper.GetFigureById(Id);
            return View(FigureData);
        }

        //Adds
        public ActionResult NewSection()
        {
            return View("NewSection");
        }


        public void SectionAdd(string SectionName, string SectionIntro)
        {

            dbHelper.AddSection(SectionName, SectionIntro);
            
        }

        public ActionResult NewCategory(int Id)
        {


            var sectionData = dbHelper.GetSectionById(Id);

            return View(sectionData);
        }

        public void CategoryAdd(string CategoryName, int SectionId)
        {

            dbHelper.AddCategory(CategoryName, SectionId);
            
        }

        public ActionResult NewSpecies(int Id)
        {

            var categoryData = dbHelper.GetCategoryById(Id);
            return View(categoryData);

        }

        public void SpeciesAdd(int CategoryId, string CommonName, string LatinName)
        {

            dbHelper.AddSpecies(CategoryId, CommonName, LatinName);
            

        }

        public ActionResult NewSighting(int Id)
        {

            var SpeciesData = dbHelper.GetSpeciesById(Id);
            return View(SpeciesData);
        }

        public void SightingAdd(int SpeciesId, DateTime WhenSeen, string WhereSeen, int HowMany, string Comment)
        {

            dbHelper.AddSighting(SpeciesId, WhenSeen, WhereSeen, HowMany, Comment);
            
        }

        public ActionResult NewFigure(int Id)
        {
            var sighting = dbHelper.GetSightingById(Id);
            return View(sighting);
        }

        public void FigureAdd(int SightingId, string Source, string Alternative, string Caption)
        {

            dbHelper.AddFigure(SightingId, Source, Alternative, Caption);
           
        }

        //Saves
        public void SectionSave(int SectionId, string SectionName, string SectionIntro)
        {

            dbHelper.SetSection(SectionId, SectionName, SectionIntro);

        }

        public void CategorySave(int CategoryId, string CategoryName)
        {

            dbHelper.SetCategory(CategoryId, CategoryName);
           

        }

        public void SpeciesSave(int SpeciesId, int CategoryId, string CommonName, string LatinName)
        {

            dbHelper.SetSpecies(SpeciesId, CommonName, LatinName);
            
        }

        public void SightingSave(int SightingId, int SpeciesId, DateTime WhenSeen, string WhereSeen, int HowMany, string Comment)
        {
            dbHelper.SetSighting(SightingId, WhenSeen, WhereSeen, HowMany, Comment);
           
        }

        public void FigureSave(int FigureId, int SightingId, string Source, string Alternative, string Caption)
        {
            dbHelper.SetFigure(FigureId, Source, Alternative, Caption);
            
        }

        //Deletes
        public void SectionDelete(int Id)
        {

            dbHelper.DeleteSection(Id);
            
        }

        public void CategoryDelete(int Id)
        {
            var category = dbHelper.GetCategoryById(Id);
            var SectionId = category.SectionModel.Id;
            dbHelper.DeleteCategory(Id);
           
        }

        public void SpeciesDelete(int Id)
        {
            var species = dbHelper.GetSpeciesById(Id);
            var CategoryId = species.CategoryModel.Id;
            dbHelper.DeleteSpecies(Id);
           
        }

        public void SightingDelete(int Id)
        {
            var sighting = dbHelper.GetSightingById(Id);
            var SpeciesId = sighting.SpeciesModel.Id;
            dbHelper.DeleteSighting(Id);
            
        }


        public void FigureDelete(int Id)
        {
            var figure = dbHelper.GetFigureById(Id);
            var SightingId = figure.SightingModel.Id;
            dbHelper.DeleteFigure(Id);
            
        }
    }
}