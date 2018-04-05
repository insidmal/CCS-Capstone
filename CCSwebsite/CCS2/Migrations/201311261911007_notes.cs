namespace CCS2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        NoteId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.NoteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notes");
        }
    }
}
