namespace InvemtoryManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saleup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sales", "ProductsId", "dbo.Products");
            DropIndex("dbo.Sales", new[] { "ProductsId" });
            DropColumn("dbo.Sales", "Vat");
            DropColumn("dbo.Sales", "Discount");
            DropColumn("dbo.Sales", "ProductsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "ProductsId", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "Discount", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "Vat", c => c.Int(nullable: false));
            CreateIndex("dbo.Sales", "ProductsId");
            AddForeignKey("dbo.Sales", "ProductsId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
