namespace RpgGameHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHandleToMeetup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meetups", "Handle", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meetups", "Handle");
        }
    }
}
