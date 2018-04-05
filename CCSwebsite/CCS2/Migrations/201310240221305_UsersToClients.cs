namespace CCS2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersToClients : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "ClientId", "dbo.Clients");
            DropIndex("dbo.Requests", new[] { "ClientId" });
            DropTable("dbo.Clients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        JoinedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateIndex("dbo.Requests", "ClientId");
            AddForeignKey("dbo.Requests", "ClientId", "dbo.Clients", "ClientId", cascadeDelete: true);
        }
    }
}
