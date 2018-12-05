using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGardenWildlife3.Models
{
    public class SectionModel
    {
        public int Id { get; set;}
        public string SectionName { get; set;}
        public string SectionIntro { get; set;}
        public virtual List<CategoryModel> CategoryList { get; set;}
    }
}