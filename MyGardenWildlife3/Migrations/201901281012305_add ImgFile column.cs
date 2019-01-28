namespace MyGardenWildlife3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImgFilecolumn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        SectionModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SectionModels", t => t.SectionModel_Id)
                .Index(t => t.SectionModel_Id);
            
            CreateTable(
                "dbo.SectionModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SectionName = c.String(),
                        SectionIntro = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SpeciesModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommonName = c.String(),
                        LatinName = c.String(),
                        CategoryModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryModels", t => t.CategoryModel_Id)
                .Index(t => t.CategoryModel_Id);
            
            CreateTable(
                "dbo.SightingModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WhereSeen = c.String(),
                        WhenSeen = c.DateTime(),
                        HowMany = c.Int(),
                        Comment = c.String(),
                        SpeciesModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SpeciesModels", t => t.SpeciesModel_Id)
                .Index(t => t.SpeciesModel_Id);
            
            CreateTable(
                "dbo.FigureModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                        Source = c.String(),
                        Alternative = c.String(),
                        ImgFile = c.Binary(),
                        SightingModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SightingModels", t => t.SightingModel_Id)
                .Index(t => t.SightingModel_Id);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SightingModels", "SpeciesModel_Id", "dbo.SpeciesModels");
            DropForeignKey("dbo.FigureModels", "SightingModel_Id", "dbo.SightingModels");
            DropForeignKey("dbo.SpeciesModels", "CategoryModel_Id", "dbo.CategoryModels");
            DropForeignKey("dbo.CategoryModels", "SectionModel_Id", "dbo.SectionModels");
            DropIndex("dbo.FigureModels", new[] { "SightingModel_Id" });
            DropIndex("dbo.SightingModels", new[] { "SpeciesModel_Id" });
            DropIndex("dbo.SpeciesModels", new[] { "CategoryModel_Id" });
            DropIndex("dbo.CategoryModels", new[] { "SectionModel_Id" });
            DropTable("dbo.UserModels");
            DropTable("dbo.FigureModels");
            DropTable("dbo.SightingModels");
            DropTable("dbo.SpeciesModels");
            DropTable("dbo.SectionModels");
            DropTable("dbo.CategoryModels");
        }
    }
}
