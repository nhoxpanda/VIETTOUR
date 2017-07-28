namespace CRM.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vs105 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_OpportunityRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Request = c.String(),
                        OpportunityId = c.Int(),
                        StaffId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_Opportunity", t => t.OpportunityId)
                .ForeignKey("dbo.tbl_Staff", t => t.StaffId)
                .Index(t => t.OpportunityId)
                .Index(t => t.StaffId);
            
            CreateTable(
                "dbo.tbl_OpportunityTransaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Note = c.String(),
                        TypeId = c.Int(),
                        OpportunityId = c.Int(),
                        StaffId = c.Int(),
                        TransactionDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_Dictionary", t => t.TypeId)
                .ForeignKey("dbo.tbl_Opportunity", t => t.OpportunityId)
                .ForeignKey("dbo.tbl_Staff", t => t.StaffId)
                .Index(t => t.TypeId)
                .Index(t => t.OpportunityId)
                .Index(t => t.StaffId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_OpportunityTransaction", "StaffId", "dbo.tbl_Staff");
            DropForeignKey("dbo.tbl_OpportunityTransaction", "OpportunityId", "dbo.tbl_Opportunity");
            DropForeignKey("dbo.tbl_OpportunityTransaction", "TypeId", "dbo.tbl_Dictionary");
            DropForeignKey("dbo.tbl_OpportunityRequest", "StaffId", "dbo.tbl_Staff");
            DropForeignKey("dbo.tbl_OpportunityRequest", "OpportunityId", "dbo.tbl_Opportunity");
            DropIndex("dbo.tbl_OpportunityTransaction", new[] { "StaffId" });
            DropIndex("dbo.tbl_OpportunityTransaction", new[] { "OpportunityId" });
            DropIndex("dbo.tbl_OpportunityTransaction", new[] { "TypeId" });
            DropIndex("dbo.tbl_OpportunityRequest", new[] { "StaffId" });
            DropIndex("dbo.tbl_OpportunityRequest", new[] { "OpportunityId" });
            DropTable("dbo.tbl_OpportunityTransaction");
            DropTable("dbo.tbl_OpportunityRequest");
        }
    }
}
