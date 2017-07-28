namespace CRM.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vs113 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Module", "Orders", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Module", "Orders");
        }
    }
}
