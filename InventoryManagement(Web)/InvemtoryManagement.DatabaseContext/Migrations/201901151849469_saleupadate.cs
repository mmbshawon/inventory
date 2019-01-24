namespace InvemtoryManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saleupadate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "SaleStyleName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "SaleStyleName");
        }
    }
}
