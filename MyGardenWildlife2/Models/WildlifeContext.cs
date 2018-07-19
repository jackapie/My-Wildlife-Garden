using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyGardenWildlife2.Models
{
    public class WildlifeContext :DbContext
    {
        const string ConnectionString = @"Server=localhost\sqlexpress;Database=Wildlife;Integrated Security=True;MultipleActiveResultSets=true";

        public WildlifeContext() : base(ConnectionString)
        {
            Database.SetInitializer<WildlifeContext>(null);
        }

        public DbSet<SectionModel> Sections { get; set; }

        public DbSet<CategoryModel> Categories { get; set; }

        public DbSet<SpeciesModel> Species { get; set; }
    }
}