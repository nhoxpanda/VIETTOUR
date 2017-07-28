namespace CRM.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vs103 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_MailImport",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Name = c.String(),
                        Phone = c.String(),
                        Note = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        StaffId = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_Staff", t => t.StaffId, cascadeDelete: true)
                .Index(t => t.StaffId);
            
            AddColumn("dbo.tbl_MailReceiveList", "MailImportId", c => c.Int());
            CreateIndex("dbo.tbl_MailReceiveList", "MailImportId");
            AddForeignKey("dbo.tbl_MailReceiveList", "MailImportId", "dbo.tbl_MailImport", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_MailReceiveList", "MailImportId", "dbo.tbl_MailImport");
            DropForeignKey("dbo.tbl_MailImport", "StaffId", "dbo.tbl_Staff");
            DropIndex("dbo.tbl_MailImport", new[] { "StaffId" });
            DropIndex("dbo.tbl_MailReceiveList", new[] { "MailImportId" });
            DropColumn("dbo.tbl_MailReceiveList", "MailImportId");
            DropTable("dbo.tbl_MailImport");
        }
    }
}
