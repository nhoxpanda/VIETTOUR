namespace CRM.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Dictionary",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Note = c.String(),
                        DictionaryCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_DictionaryCategory", t => t.DictionaryCategoryId, cascadeDelete: true)
                .Index(t => t.DictionaryCategoryId);
            
            CreateTable(
                "dbo.tbl_DictionaryCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Dictionary", "DictionaryCategoryId", "dbo.tbl_DictionaryCategory");
            DropIndex("dbo.tbl_Dictionary", new[] { "DictionaryCategoryId" });
            DropTable("dbo.tbl_DictionaryCategory");
            DropTable("dbo.tbl_Dictionary");
        }
    }
}
