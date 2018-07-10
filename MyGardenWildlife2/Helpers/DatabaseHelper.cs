using MyGardenWildlife2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGardenWildlife2.Helpers
{
    public class DatabaseHelper
    {

        public static List<CategoryModel> GetInvertsData()
        {
            var context = new WildlifeContext();

            var result = context.Categories.ToList();


            
            return result;

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