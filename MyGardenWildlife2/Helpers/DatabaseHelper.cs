﻿using MyGardenWildlife2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGardenWildlife2.Helpers
{
    public class DatabaseHelper

    {
        //SectionModel is the type, GetSection therefore is of the type SectionMode
        //GetSection takes a parameter that is SectionName, a string.
        public static SectionModel GetSection(string SectionName)
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