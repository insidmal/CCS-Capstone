namespace CCS2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "Service_ServiceId", "dbo.Services");
            DropIndex("dbo.Requests", new[] { "Service_ServiceId" });
            AddColumn("dbo.Requests", "ServiceId", c => c.Int(nullable: false));
            DropColumn("dbo.Requests", "Service_ServiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "Service_ServiceId", c => c.Int());
            DropColumn("dbo.Requests", "ServiceId");
            CreateIndex("dbo.Requests", "Service_ServiceId");
            AddForeignKey("dbo.Requests", "Service_ServiceId", "dbo.Services", "ServiceId");
        }
    }
}
