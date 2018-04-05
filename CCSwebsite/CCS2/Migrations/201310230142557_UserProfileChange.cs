namespace CCS2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProfileChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProfile", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.UserProfile", new[] { "Client_ClientId" });
            AddColumn("dbo.UserProfile", "Name", c => c.String(nullable: false));
            AddColumn("dbo.UserProfile", "Email", c => c.String(nullable: false));
            AddColumn("dbo.UserProfile", "JoinedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Requests", "UserProfile_UserProfileId", c => c.Int());
            AddForeignKey("dbo.Requests", "UserProfile_UserProfileId", "dbo.UserProfile", "UserProfileId");
            CreateIndex("dbo.Requests", "UserProfile_UserProfileId");
            DropColumn("dbo.UserProfile", "Client_ClientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfile", "Client_ClientId", c => c.Int());
            DropIndex("dbo.Requests", new[] { "UserProfile_UserProfileId" });
            DropForeignKey("dbo.Requests", "UserProfile_UserProfileId", "dbo.UserProfile");
            DropColumn("dbo.Requests", "UserProfile_UserProfileId");
            DropColumn("dbo.UserProfile", "JoinedOn");
            DropColumn("dbo.UserProfile", "Email");
            DropColumn("dbo.UserProfile", "Name");
            CreateIndex("dbo.UserProfile", "Client_ClientId");
            AddForeignKey("dbo.UserProfile", "Client_ClientId", "dbo.Clients", "ClientId");
        }
    }
}
