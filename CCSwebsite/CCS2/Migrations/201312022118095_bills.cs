namespace CCS2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bills : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FileName = c.String(),
                        FileExtension = c.String(),
                        FileContent = c.Binary(),
                    })
                .PrimaryKey(t => t.BillId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bills");
        }
    }
}
