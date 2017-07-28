namespace CRM.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vs107 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_LiabilityCustomer", "IsContract", c => c.Boolean(nullable: false));
            AddColumn("dbo.tbl_LiabilityCustomer", "IsBill", c => c.Boolean(nullable: false));
            AddColumn("dbo.tbl_LiabilityCustomer", "IsPPVS", c => c.Boolean(nullable: false));
            AddColumn("dbo.tbl_LiabilityCustomer", "FullNote", c => c.String());
            AddColumn("dbo.tbl_LiabilityCustomer", "TotalVisa", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.tbl_LiabilityCustomer", "TotalReturn", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.tbl_LiabilityCustomer", "ThirdPrice");
            DropColumn("dbo.tbl_LiabilityCustomer", "ThirdDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_LiabilityCustomer", "ThirdDate", c => c.DateTime());
            AddColumn("dbo.tbl_LiabilityCustomer", "ThirdPrice", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.tbl_LiabilityCustomer", "TotalReturn");
            DropColumn("dbo.tbl_LiabilityCustomer", "TotalVisa");
            DropColumn("dbo.tbl_LiabilityCustomer", "FullNote");
            DropColumn("dbo.tbl_LiabilityCustomer", "IsPPVS");
            DropColumn("dbo.tbl_LiabilityCustomer", "IsBill");
            DropColumn("dbo.tbl_LiabilityCustomer", "IsContract");
        }
    }
}
