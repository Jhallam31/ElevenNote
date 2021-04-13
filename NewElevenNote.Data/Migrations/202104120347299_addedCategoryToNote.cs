namespace NewElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCategoryToNote : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Note", "CategoryId", "dbo.Category");
            DropPrimaryKey("dbo.Category");
            AddColumn("dbo.Category", "CategoryId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Note", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Category", "Name", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Category", "CategoryId");
            CreateIndex("dbo.Note", "CategoryId");
            AddForeignKey("dbo.Note", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Note", "CategoryId", "dbo.Category");
            DropIndex("dbo.Note", new[] { "CategoryId" });
            DropPrimaryKey("dbo.Category");
            AlterColumn("dbo.Category", "Name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Note", "CategoryId");
            DropColumn("dbo.Category", "CategoryId");
            AddPrimaryKey("dbo.Category", "Name");
            AddForeignKey("dbo.Note", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
        }
    }
}
