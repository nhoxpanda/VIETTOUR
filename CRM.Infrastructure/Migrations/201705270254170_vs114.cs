namespace CRM.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vs114 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Form", "Controller", c => c.String());
            AddColumn("dbo.tbl_Form", "Action", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Form", "Action");
            DropColumn("dbo.tbl_Form", "Controller");
        }
    }
}
