namespace NewElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCommentClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        OwnerId = c.String(),
                        CommentDate = c.DateTimeOffset(nullable: false, precision: 7),
                        NoteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Note", t => t.NoteId, cascadeDelete: true)
                .Index(t => t.NoteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "NoteId", "dbo.Note");
            DropIndex("dbo.Comment", new[] { "NoteId" });
            DropTable("dbo.Comment");
        }
    }
}
