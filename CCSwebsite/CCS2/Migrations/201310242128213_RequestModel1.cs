namespace CCS2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestModel1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserProfile", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfile", "Name", c => c.String(nullable: false));
        }
    }
}
