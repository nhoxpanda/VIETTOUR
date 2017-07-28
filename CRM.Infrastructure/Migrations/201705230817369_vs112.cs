namespace CRM.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vs112 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Customer", "IsTour", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Customer", "IsTour");
        }
    }
}
