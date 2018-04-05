namespace CCS2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "ClientId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "ClientId");
        }
    }
}
