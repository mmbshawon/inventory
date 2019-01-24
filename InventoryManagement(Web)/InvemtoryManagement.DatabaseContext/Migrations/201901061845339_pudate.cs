namespace InvemtoryManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pudate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductQuantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProductQuantity");
        }
    }
}
