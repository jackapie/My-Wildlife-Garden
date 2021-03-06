﻿using MyGardenWildlife2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGardenWildlife2.Controllers
{
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
            return View("CategoryList", section);

        }

        public ActionResult SpeciesList(int Id)
        {
            
            var category = dbHelper.GetCategoryById(Id);
            return View("SpeciesList", category);
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
            return View("sectionEdit", sectionData);
        }

        public ActionResult CategoryEdit(int Id)
        {
            
            var CategoryData = dbHelper.GetCategoryById(Id);
            return View("categoryEdit", CategoryData);
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


        public ActionResult SectionAdd(string SectionName, string SectionIntro)
        {
            
            dbHelper.AddSection(SectionName, SectionIntro);
            return RedirectToAction("SectionList");
        }

        public ActionResult NewCategory(int Id)
        {

            
            var sectionData = dbHelper.GetSectionById(Id);

            return View(sectionData);
        }

        public ActionResult CategoryAdd(string CategoryName, int SectionId)
        {
           
            dbHelper.AddCategory(CategoryName, SectionId);
            return RedirectToAction("CategoryList", new { Id = SectionId });
        }

        public ActionResult NewSpecies(int Id)
        {
            
            var categoryData = dbHelper.GetCategoryById(Id);
            return View(categoryData);
            
        }

        public ActionResult SpeciesAdd(int CategoryId, string CommonName, string LatinName)
        {
            
            dbHelper.AddSpecies(CategoryId, CommonName, LatinName);
            return RedirectToAction("SpeciesList", new { Id = CategoryId });

        }

        public ActionResult NewSighting(int Id)
        {
            
            var SpeciesData = dbHelper.GetSpeciesById(Id);
            return View(SpeciesData);
        }

        public ActionResult SightingAdd(int SpeciesId, DateTime When, string Where, int HowMany, string Comment)
        {
            
            dbHelper.AddSighting(SpeciesId, When, Where, HowMany, Comment);
            return RedirectToAction("SightingList", new { Id = SpeciesId });
        }

        public ActionResult NewFigure(int Id)
        {
            var sighting = dbHelper.GetSightingById(Id);
            return View(sighting);
        }

        public ActionResult FigureAdd(int SightingId, string Source, string Alternative, string Caption)
        {
            
            dbHelper.AddFigure(SightingId, Source, Alternative, Caption);
            return RedirectToAction("FigureList", new { Id = SightingId });
        }

        //Saves
        public ActionResult SectionSave(int SectionId, string SectionName, string SectionIntro)
        {
            

            dbHelper.SetSection(SectionId, SectionName, SectionIntro);

            return RedirectToAction("SectionList");
        }
      
        public ActionResult CategorySave(int CategoryId, string CategoryName, int SectionId)
        {
            
            dbHelper.SetCategory(CategoryId, CategoryName);
            return RedirectToAction("CategoryList", new { Id = SectionId});

        }

        public ActionResult SpeciesSave(int SpeciesId, int CategoryId, string CommonName, string LatinName)
        {
            
            dbHelper.SetSpecies(SpeciesId, CommonName, LatinName);
            return RedirectToAction("SpeciesList", new { id = CategoryId });
        }

        public ActionResult SightingSave(int SightingId, int SpeciesId, DateTime WhenSeen, string WhereSeen, int HowMany, string Comment)
        {
            dbHelper.SetSighting(SightingId, WhenSeen, WhereSeen, HowMany, Comment);
            return RedirectToAction("SightingList", new { id = SpeciesId });
        }

        public ActionResult FigureSave(int FigureId, int SightingId, string Source, string Alternative, string Caption)
        {
            dbHelper.SetFigure(FigureId, Source, Alternative, Caption);
            return RedirectToAction("FigureList", new { id = SightingId });
        }

        //Deletes
        public ActionResult SectionDelete(int Id)
        {
                        
            dbHelper.DeleteSection(Id);
            return RedirectToAction("SectionList");
        }

        public ActionResult CategoryDelete(int Id)
        {
            var category = dbHelper.GetCategoryById(Id);
            var SectionId = category.SectionModel.Id;
            dbHelper.DeleteCategory(Id);
            return RedirectToAction("CategoryList", new { id = SectionId });
        }

        public ActionResult SpeciesDelete(int Id)
        {
            var species = dbHelper.GetSpeciesById(Id);
            var CategoryId = species.CategoryModel.Id;
            dbHelper.DeleteSpecies(Id);
            return RedirectToAction("SpeciesList", new { id = CategoryId });
        }

        public ActionResult SightingDelete(int Id)
        {
            var sighting = dbHelper.GetSightingById(Id);
            var SpeciesId = sighting.SpeciesModel.Id;
            dbHelper.DeleteSighting(Id);
            return RedirectToAction("SightingList", new { id = SpeciesId });
        }


        public ActionResult FigureDelete(int Id)
        {
            var figure = dbHelper.GetFigureById(Id);
            var SightingId = figure.SightingModel.Id;
            dbHelper.DeleteFigure(Id);
            return RedirectToAction("FigureList", new { id = SightingId });
        }
    }
}