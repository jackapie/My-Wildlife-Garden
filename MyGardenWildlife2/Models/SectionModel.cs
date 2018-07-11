using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGardenWildlife2.Models
{
    public class SectionModel
    {
        public int Id { get; set;}
        public string SectionName { get; set;}
        public virtual List<CategoryModel> CategoryList { get; set;}
    }
}