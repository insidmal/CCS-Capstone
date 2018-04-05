namespace CCS2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messageSendTo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "SentTo", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "SentTo");
        }
    }
}
