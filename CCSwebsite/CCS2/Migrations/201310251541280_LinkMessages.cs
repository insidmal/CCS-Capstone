namespace CCS2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkMessages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ReplyId", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "DateReceived", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "DateReceived");
            DropColumn("dbo.Messages", "ReplyId");
        }
    }
}
