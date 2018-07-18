using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyGardenWildlife2.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual List <SpeciesModel> SpeciesList { get; set; }
        public virtual SectionModel SectionModel { get; set; }
    }
}