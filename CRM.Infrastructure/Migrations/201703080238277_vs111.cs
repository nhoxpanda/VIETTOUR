namespace CRM.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vs111 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_TourCustomerService",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        LiabilityCustomerId = c.Int(nullable: false),
                        ServiceName = c.String(),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(),
                        TotalPrice = c.Double(),
                        CurrencyId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.tbl_Dictionary", t => t.CurrencyId)
                .ForeignKey("dbo.tbl_LiabilityCustomer", t => t.LiabilityCustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.LiabilityCustomerId)
                .Index(t => t.CurrencyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_TourCustomerService", "LiabilityCustomerId", "dbo.tbl_LiabilityCustomer");
            DropForeignKey("dbo.tbl_TourCustomerService", "CurrencyId", "dbo.tbl_Dictionary");
            DropForeignKey("dbo.tbl_TourCustomerService", "CustomerId", "dbo.tbl_Customer");
            DropIndex("dbo.tbl_TourCustomerService", new[] { "CurrencyId" });
            DropIndex("dbo.tbl_TourCustomerService", new[] { "LiabilityCustomerId" });
            DropIndex("dbo.tbl_TourCustomerService", new[] { "CustomerId" });
            DropTable("dbo.tbl_TourCustomerService");
        }
    }
}
