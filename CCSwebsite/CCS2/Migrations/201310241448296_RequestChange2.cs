namespace CCS2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestChange2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Requests", "ClientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "ClientId", c => c.Int(nullable: false));
        }
    }
}
