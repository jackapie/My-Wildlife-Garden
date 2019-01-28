using MyGardenWildlife3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGardenWildlife3.Helpers
{
    public class DatabaseHelper

    {  /*Loop through each category.
             *For each category, loop through species
             * For each species, show CommonName, LatinName, and if applicable, sighting information.
             * Sighting information to show includes When, where, how many (if given), comments (if given) and a figure (if applicable)
             * Where there is a figure, show the caption and retrieve the image.
             * The image has a source and an alternative.
             */
        
        public SectionModel GetSection(string SectionName)
        {
            
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

        public SightingModel GetSightingById(int SightingId)
        {
            var context = new WildlifeContext();
            var sighting = context.Sighting.Where((e) => e.Id == SightingId).First();
            return sighting;
        }

        public FigureModel GetFigureById(int FigureId)
        {
            var context = new WildlifeContext();
            var figure = context.Figure.Where((e) => e.Id == FigureId).First();
            return figure;
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

        public void SetSighting(int SightingId, DateTime WhenSeen, string WhereSeen, int HowMany, string Comment)
        {
            var context = new WildlifeContext();
            var sighting = context.Sighting.Where((e) => e.Id == SightingId).First();
            sighting.WhenSeen = WhenSeen;
            sighting.WhereSeen = WhereSeen;
            sighting.HowMany = HowMany;
            sighting.Comment = Comment;
            context.SaveChanges();
        }

        public void SetFigure(int FigureId, string Source, string Alternative, string Caption)
        {
            var context = new WildlifeContext();
            var figure = context.Figure.Where((e) => e.Id == FigureId).First();
            figure.Source = Source;
            figure.Alternative = Alternative;
            figure.Caption = Caption;
            context.SaveChanges();
        }

        //Add

        public void AddSection(string SectionName, string SectionIntro)
        {
            var context = new WildlifeContext();
            var section = new SectionModel();
            context.Sections.Add(section);
            section.SectionName = SectionName;
            section.SectionIntro = SectionIntro;
            context.SaveChanges();
        }

        public void AddCategory(string CategoryName, int SectionId)
        {
            var context = new WildlifeContext();
            var section = context.Sections.Where((e) => e.Id == SectionId).First();
            var category = new CategoryModel();

            (section.CategoryList).Add(category);
            category.CategoryName = CategoryName;
            context.SaveChanges();
        }

        public void AddSpecies(int CategoryId, string CommonName, string LatinName)
        {
            var context = new WildlifeContext();
            var category = context.Categories.Where((e) => e.Id == CategoryId).First();
            var species = new SpeciesModel();
            category.SpeciesList.Add(species);
            species.CommonName = CommonName;
            species.LatinName = LatinName;
            context.SaveChanges();
        }

        public void AddSighting(int SpeciesId, DateTime WhenSeen, string WhereSeen, int HowMany, string Comment)
        {
            var context = new WildlifeContext();
            var species = context.Species.Where((e) => e.Id == SpeciesId).First();
            var sighting = new SightingModel();
            species.SightingList.Add(sighting);
            sighting.WhenSeen = WhenSeen;
            sighting.WhereSeen = WhereSeen;
            sighting.HowMany = HowMany;
            sighting.Comment = Comment;
            context.SaveChanges();
        }

        public void AddFigure(int SightingId, string Source, string Alternative, string Caption, byte[] imgByteArray)
        {
            var context = new WildlifeContext();
            var sighting = context.Sighting.Where((e) => e.Id == SightingId).First();
            var figure = new FigureModel();
            sighting.FigureList.Add(figure);
            figure.Source = Source;
            figure.Alternative = Alternative;
            figure.Caption = Caption;
            figure.ImgFile = imgByteArray;
            context.SaveChanges();

        }

        //Deletes
        public void DeleteSection(int SectionId)
        {
            var context = new WildlifeContext();
            var section = context.Sections.Where((e) => e.Id == SectionId).First();
            context.Sections.Remove(section);
            context.SaveChanges();
        }

        public void DeleteCategory(int CategoryId)
        {
            var context = new WildlifeContext();
            var category = context.Categories.Where((e) => e.Id == CategoryId).First();
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public void DeleteSpecies(int SpeciesId)
        {
            var context = new WildlifeContext();
            var species = context.Species.Where((e) => e.Id == SpeciesId).First();
            context.Species.Remove(species);
            context.SaveChanges();
        }



        public void DeleteSighting(int SightingId)
        {
            var context = new WildlifeContext();
            var sighting = context.Sighting.Where((e) => e.Id == SightingId).First();
            context.Sighting.Remove(sighting);
            context.SaveChanges();
        }

        public void DeleteFigure(int FigureId)
        {
            var context = new WildlifeContext();
            var figure = context.Figure.Where((e) => e.Id == FigureId).First();
            context.Figure.Remove(figure);
            context.SaveChanges();
        }



    }
}