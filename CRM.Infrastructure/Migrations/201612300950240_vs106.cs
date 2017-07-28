namespace CRM.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vs106 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Customer", "Username", c => c.String());
            AddColumn("dbo.tbl_Customer", "Password", c => c.String());
            AddColumn("dbo.tbl_Customer", "IsSendAccount", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Customer", "IsSendAccount");
            DropColumn("dbo.tbl_Customer", "Password");
            DropColumn("dbo.tbl_Customer", "Username");
        }
    }
}
