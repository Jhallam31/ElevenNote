namespace NewElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigrate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Note", "OwnerId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Note", "OwnerId", c => c.Guid(nullable: false));
        }
    }
}
