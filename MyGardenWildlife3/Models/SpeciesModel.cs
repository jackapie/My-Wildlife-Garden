﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGardenWildlife3.Models
{
    public class SpeciesModel
    {
        public int Id { get; set; }
        public string CommonName { get; set; }
        public string LatinName { get; set; }
        public virtual List<SightingModel> SightingList { get; set; }
        public virtual CategoryModel CategoryModel { get; set;}
    }
}