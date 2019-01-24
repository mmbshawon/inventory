namespace InvemtoryManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saleupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "ProductPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "ProductPrice");
        }
    }
}
