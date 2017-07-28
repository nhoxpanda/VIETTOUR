namespace CRM.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vs115 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Form", "IsMenu", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Form", "IsMenu");
        }
    }
}
