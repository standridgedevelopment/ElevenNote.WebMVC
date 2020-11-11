namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Note", "CategoryID", "dbo.Category");
            DropIndex("dbo.Note", new[] { "CategoryID" });
            DropTable("dbo.Category");
            DropTable("dbo.Note");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Note",
                c => new
                    {
                        NoteID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.NoteID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ListOfNotes = c.String(),
                        NumberOfLists = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateIndex("dbo.Note", "CategoryID");
            AddForeignKey("dbo.Note", "CategoryID", "dbo.Category", "CategoryID", cascadeDelete: true);
        }
    }
}
