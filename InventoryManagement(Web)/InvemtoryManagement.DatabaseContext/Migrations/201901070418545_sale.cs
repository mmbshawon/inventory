namespace InvemtoryManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Saledate = c.DateTime(nullable: false),
                        SaleQuantity = c.Int(nullable: false),
                        Vat = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        ProductsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductsId, cascadeDelete: true)
                .Index(t => t.ProductsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "ProductsId", "dbo.Products");
            DropIndex("dbo.Sales", new[] { "ProductsId" });
            DropTable("dbo.Sales");
        }
    }
}
