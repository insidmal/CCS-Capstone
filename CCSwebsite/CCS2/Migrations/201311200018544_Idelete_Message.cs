namespace CCS2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Idelete_Message : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "UserDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "AdminDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "AdminDelete");
            DropColumn("dbo.Messages", "UserDelete");
        }
    }
}
