using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGardenWildlife3.Models
{
    public class FigureModel
    {
        public int Id { get; set; }
        
        public string Caption { get; set; }
        public string Source { get; set; }
        public string Alternative { get; set; }
        public virtual SightingModel SightingModel { get; set; }
        public byte[] ImgFile { get; set; }
    }
}