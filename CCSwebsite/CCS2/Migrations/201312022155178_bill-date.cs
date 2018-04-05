namespace CCS2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "Date");
        }
    }
}
