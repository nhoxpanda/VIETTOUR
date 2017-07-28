namespace CRM.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vs110 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_VisaInfomation", "ExpirationDay", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_VisaInfomation", "ExpirationDay");
        }
    }
}
