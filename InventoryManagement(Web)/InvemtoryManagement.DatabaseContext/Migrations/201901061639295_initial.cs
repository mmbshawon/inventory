namespace InvemtoryManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CodeCares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CaresName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CodeColors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColorsName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CodeFabrics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FabricsName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CodeFits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FitsName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CodeProductGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductGroupsName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CodeProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductTypesName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CodeSeasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeasonsName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false),
                        CustomerId = c.String(nullable: false),
                        CustomerEmail = c.String(nullable: false),
                        CustomerPhone = c.String(nullable: false),
                        CustomerAddress = c.String(nullable: false),
                        CustomerPoint = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StyleName = c.String(nullable: false),
                        Dpp = c.Int(nullable: false),
                        Dsp = c.Int(nullable: false),
                        CodeSeasonsId = c.Int(nullable: false),
                        CodeProductGroupsId = c.Int(nullable: false),
                        CodeProductTypesId = c.Int(nullable: false),
                        CodeFabricsId = c.Int(nullable: false),
                        CodeFitsId = c.Int(nullable: false),
                        CodeCaresId = c.Int(nullable: false),
                        CodeColorsId = c.Int(nullable: false),
                        ProductSizesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CodeCares", t => t.CodeCaresId, cascadeDelete: true)
                .ForeignKey("dbo.CodeColors", t => t.CodeColorsId, cascadeDelete: true)
                .ForeignKey("dbo.CodeFabrics", t => t.CodeFabricsId, cascadeDelete: true)
                .ForeignKey("dbo.CodeFits", t => t.CodeFitsId, cascadeDelete: true)
                .ForeignKey("dbo.CodeProductGroups", t => t.CodeProductGroupsId, cascadeDelete: true)
                .ForeignKey("dbo.CodeProductTypes", t => t.CodeProductTypesId, cascadeDelete: true)
                .ForeignKey("dbo.CodeSeasons", t => t.CodeSeasonsId, cascadeDelete: true)
                .ForeignKey("dbo.ProductSizes", t => t.ProductSizesId, cascadeDelete: true)
                .Index(t => t.CodeSeasonsId)
                .Index(t => t.CodeProductGroupsId)
                .Index(t => t.CodeProductTypesId)
                .Index(t => t.CodeFabricsId)
                .Index(t => t.CodeFitsId)
                .Index(t => t.CodeCaresId)
                .Index(t => t.CodeColorsId)
                .Index(t => t.ProductSizesId);
            
            CreateTable(
                "dbo.ProductSizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SizesName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductStocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SSize = c.Int(nullable: false),
                        MSize = c.Int(nullable: false),
                        LSizw = c.Int(nullable: false),
                        XlSizw = c.Int(nullable: false),
                        XxlSize = c.Int(nullable: false),
                        ProductsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductsId, cascadeDelete: true)
                .Index(t => t.ProductsId);
            
            CreateTable(
                "dbo.TestModelForDbs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductStocks", "ProductsId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductSizesId", "dbo.ProductSizes");
            DropForeignKey("dbo.Products", "CodeSeasonsId", "dbo.CodeSeasons");
            DropForeignKey("dbo.Products", "CodeProductTypesId", "dbo.CodeProductTypes");
            DropForeignKey("dbo.Products", "CodeProductGroupsId", "dbo.CodeProductGroups");
            DropForeignKey("dbo.Products", "CodeFitsId", "dbo.CodeFits");
            DropForeignKey("dbo.Products", "CodeFabricsId", "dbo.CodeFabrics");
            DropForeignKey("dbo.Products", "CodeColorsId", "dbo.CodeColors");
            DropForeignKey("dbo.Products", "CodeCaresId", "dbo.CodeCares");
            DropIndex("dbo.ProductStocks", new[] { "ProductsId" });
            DropIndex("dbo.Products", new[] { "ProductSizesId" });
            DropIndex("dbo.Products", new[] { "CodeColorsId" });
            DropIndex("dbo.Products", new[] { "CodeCaresId" });
            DropIndex("dbo.Products", new[] { "CodeFitsId" });
            DropIndex("dbo.Products", new[] { "CodeFabricsId" });
            DropIndex("dbo.Products", new[] { "CodeProductTypesId" });
            DropIndex("dbo.Products", new[] { "CodeProductGroupsId" });
            DropIndex("dbo.Products", new[] { "CodeSeasonsId" });
            DropTable("dbo.TestModelForDbs");
            DropTable("dbo.ProductStocks");
            DropTable("dbo.ProductSizes");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
            DropTable("dbo.CodeSeasons");
            DropTable("dbo.CodeProductTypes");
            DropTable("dbo.CodeProductGroups");
            DropTable("dbo.CodeFits");
            DropTable("dbo.CodeFabrics");
            DropTable("dbo.CodeColors");
            DropTable("dbo.CodeCares");
        }
    }
}
