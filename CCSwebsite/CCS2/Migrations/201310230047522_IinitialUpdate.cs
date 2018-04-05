namespace CCS2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IinitialUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserProfileId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Client_ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.UserProfileId)
                .ForeignKey("dbo.Clients", t => t.Client_ClientId)
                .Index(t => t.Client_ClientId);
            
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
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        DateRequested = c.DateTime(nullable: false),
                        Description = c.String(),
                        Approved = c.Boolean(nullable: false),
                        CompleteDate = c.DateTime(nullable: false),
                        Service_ServiceId = c.Int(),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Services", t => t.Service_ServiceId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.Service_ServiceId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Brief = c.String(),
                        Featured = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Requests", new[] { "ClientId" });
            DropIndex("dbo.Requests", new[] { "Service_ServiceId" });
            DropIndex("dbo.UserProfile", new[] { "Client_ClientId" });
            DropForeignKey("dbo.Requests", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Requests", "Service_ServiceId", "dbo.Services");
            DropForeignKey("dbo.UserProfile", "Client_ClientId", "dbo.Clients");
            DropTable("dbo.Services");
            DropTable("dbo.Requests");
            DropTable("dbo.Clients");
            DropTable("dbo.UserProfile");
        }
    }
}
