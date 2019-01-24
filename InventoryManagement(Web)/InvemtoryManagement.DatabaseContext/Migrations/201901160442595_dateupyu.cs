namespace InvemtoryManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateupyu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "SaleProductName", c => c.String());
            DropColumn("dbo.Sales", "SaleStyleName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "SaleStyleName", c => c.String());
            DropColumn("dbo.Sales", "SaleProductName");
        }
    }
}
