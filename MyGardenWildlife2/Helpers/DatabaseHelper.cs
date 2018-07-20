using MyGardenWildlife2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGardenWildlife2.Helpers
{
    public class DatabaseHelper

    {
        //SectionModel is the return type, GetSection is a function that returns an object of type SectionModel.
        //GetSection takes a parameter that is SectionName, a string.
        public SectionModel GetSection(string SectionName)
        {
            //Create an object of type WildlifeContext, assign this to variable "context"
            var context = new WildlifeContext();

            //Within the WildlifeContext object "context", call "Sections", a property within WildlifeContext, returns an object
            //On this new object, call a Where function, returns an object.  
            //On this new object, call the First function, returns an object 
            //Assign this new object to variable "section"
            var section = context.Sections.Where((e) => e.SectionName == SectionName).First();
            
            //Sets the result of the overall function to be "section", and exits the function.
            return section;

        }
         //Get functions
        public List<SectionModel> GetSectionList()
        {
            var context = new WildlifeContext();

            var SectionList = context.Sections.ToList();

            return SectionList;

        }

        public SectionModel GetSectionById(int SectionId)
        {
            var context = new WildlifeContext();

            var section = context.Sections.Where((e) => e.Id == SectionId).First();

            return section;
        }

        public CategoryModel GetCategoryById(int CategoryId)
        {
            var context = new WildlifeContext();

            var category = context.Categories.Where((e) => e.Id == CategoryId).First();
            return category;
        }

        public SpeciesModel GetSpeciesById(int SpeciesId)
        {
            var context = new WildlifeContext();
            var species = context.Species.Where((e) => e.Id == SpeciesId).First();
            return species;
        }

        //Set functions
        public void SetSection(int SectionId, string SectionName, string SectionIntro)
        {
            var context = new WildlifeContext();
            var section = context.Sections.Where((e) => e.Id == SectionId).First();

            section.SectionName = SectionName;
            section.SectionIntro = SectionIntro;
            context.SaveChanges();
        }

        public void SetCategory(int CategoryId, string CategoryName)
        {
            var context = new WildlifeContext();
            var category = context.Categories.Where((e) => e.Id == CategoryId).First();

            category.CategoryName = CategoryName;
            context.SaveChanges();
        }

        public void SetSpecies(int SpeciesId, string CommonName, string LatinName)
        {
            var context = new WildlifeContext();
            var species = context.Species.Where((e) => e.Id == SpeciesId).First();
            species.CommonName = CommonName;
            species.LatinName = LatinName;
            context.SaveChanges();
        }

        






            /*Loop through each category.
             *For each category, loop through species
             * For each species, show CommonName, LatinName, and if applicable, sighting information.
             * Sighting information to show includes When, where, how many (if given), comments (if given) and a figure (if applicable)
             * Where there is a figure, show the caption and retrieve the image.
             * The image has a source and an alternative.
             * 
             * 
             * 
             * 
             * 
             */
        }
}