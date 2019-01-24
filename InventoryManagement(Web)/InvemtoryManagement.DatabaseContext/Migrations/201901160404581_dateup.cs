namespace InvemtoryManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "SaleDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Sales", "Saledate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "Saledate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Sales", "SaleDateTime");
        }
    }
}
