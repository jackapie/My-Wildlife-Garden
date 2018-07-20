﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGardenWildlife2.Models
{
    public class SightingModel
    {
        public int Id { get; set; }
        public string Where { get; set; }
        public DateTime? When { get; set; }
        public int? HowMany { get; set; }
        public string Comment { get; set; }
        public virtual List<FigureModel> Figure { get; set; }
        public virtual SpeciesModel SpeciesModel { get; set; }

    }
}