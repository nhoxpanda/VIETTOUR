namespace CRM.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vs104 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Opportunity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        GroupId = c.Int(),
                        FormContactId = c.Int(),
                        StatusId = c.Int(),
                        TiemNang = c.Double(),
                        CustomerId = c.Int(),
                        ManagerId = c.Int(),
                        StaffId = c.Int(),
                        Note = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_Customer", t => t.CustomerId)
                .ForeignKey("dbo.tbl_Dictionary", t => t.FormContactId)
                .ForeignKey("dbo.tbl_Dictionary", t => t.GroupId)
                .ForeignKey("dbo.tbl_Dictionary", t => t.StatusId)
                .ForeignKey("dbo.tbl_Staff", t => t.StaffId)
                .ForeignKey("dbo.tbl_Staff", t => t.ManagerId)
                .Index(t => t.GroupId)
                .Index(t => t.FormContactId)
                .Index(t => t.StatusId)
                .Index(t => t.CustomerId)
                .Index(t => t.ManagerId)
                .Index(t => t.StaffId);
            
            CreateTable(
                "dbo.tbl_Competitor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Advantage = c.String(),
                        Disadvantage = c.String(),
                        StaffId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        OpportunityId = c.Int(),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_Opportunity", t => t.OpportunityId)
                .ForeignKey("dbo.tbl_Staff", t => t.StaffId)
                .Index(t => t.StaffId)
                .Index(t => t.OpportunityId);
            
            AddColumn("dbo.tbl_AppointmentHistory", "OpportunityId", c => c.Int());
            AddColumn("dbo.tbl_ContactHistory", "Opportunity", c => c.Int());
            AddColumn("dbo.tbl_DocumentFile", "OpportunityId", c => c.Int());
            AddColumn("dbo.tbl_UpdateHistory", "OpportunityId", c => c.Int());
            CreateIndex("dbo.tbl_AppointmentHistory", "OpportunityId");
            CreateIndex("dbo.tbl_ContactHistory", "Opportunity");
            CreateIndex("dbo.tbl_DocumentFile", "OpportunityId");
            CreateIndex("dbo.tbl_UpdateHistory", "OpportunityId");
            AddForeignKey("dbo.tbl_UpdateHistory", "OpportunityId", "dbo.tbl_Opportunity", "Id");
            AddForeignKey("dbo.tbl_DocumentFile", "OpportunityId", "dbo.tbl_Opportunity", "Id");
            AddForeignKey("dbo.tbl_ContactHistory", "Opportunity", "dbo.tbl_Opportunity", "Id");
            AddForeignKey("dbo.tbl_AppointmentHistory", "OpportunityId", "dbo.tbl_Opportunity", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_AppointmentHistory", "OpportunityId", "dbo.tbl_Opportunity");
            DropForeignKey("dbo.tbl_ContactHistory", "Opportunity", "dbo.tbl_Opportunity");
            DropForeignKey("dbo.tbl_DocumentFile", "OpportunityId", "dbo.tbl_Opportunity");
            DropForeignKey("dbo.tbl_UpdateHistory", "OpportunityId", "dbo.tbl_Opportunity");
            DropForeignKey("dbo.tbl_Opportunity", "ManagerId", "dbo.tbl_Staff");
            DropForeignKey("dbo.tbl_Opportunity", "StaffId", "dbo.tbl_Staff");
            DropForeignKey("dbo.tbl_Opportunity", "StatusId", "dbo.tbl_Dictionary");
            DropForeignKey("dbo.tbl_Opportunity", "GroupId", "dbo.tbl_Dictionary");
            DropForeignKey("dbo.tbl_Opportunity", "FormContactId", "dbo.tbl_Dictionary");
            DropForeignKey("dbo.tbl_Opportunity", "CustomerId", "dbo.tbl_Customer");
            DropForeignKey("dbo.tbl_Competitor", "StaffId", "dbo.tbl_Staff");
            DropForeignKey("dbo.tbl_Competitor", "OpportunityId", "dbo.tbl_Opportunity");
            DropIndex("dbo.tbl_UpdateHistory", new[] { "OpportunityId" });
            DropIndex("dbo.tbl_Competitor", new[] { "OpportunityId" });
            DropIndex("dbo.tbl_Competitor", new[] { "StaffId" });
            DropIndex("dbo.tbl_Opportunity", new[] { "StaffId" });
            DropIndex("dbo.tbl_Opportunity", new[] { "ManagerId" });
            DropIndex("dbo.tbl_Opportunity", new[] { "CustomerId" });
            DropIndex("dbo.tbl_Opportunity", new[] { "StatusId" });
            DropIndex("dbo.tbl_Opportunity", new[] { "FormContactId" });
            DropIndex("dbo.tbl_Opportunity", new[] { "GroupId" });
            DropIndex("dbo.tbl_DocumentFile", new[] { "OpportunityId" });
            DropIndex("dbo.tbl_ContactHistory", new[] { "Opportunity" });
            DropIndex("dbo.tbl_AppointmentHistory", new[] { "OpportunityId" });
            DropColumn("dbo.tbl_UpdateHistory", "OpportunityId");
            DropColumn("dbo.tbl_DocumentFile", "OpportunityId");
            DropColumn("dbo.tbl_ContactHistory", "Opportunity");
            DropColumn("dbo.tbl_AppointmentHistory", "OpportunityId");
            DropTable("dbo.tbl_Competitor");
            DropTable("dbo.tbl_Opportunity");
        }
    }
}
