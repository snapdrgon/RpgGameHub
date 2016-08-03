namespace RpgGameHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHubFieldToMeetupTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meetups", "Hub", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meetups", "Hub");
        }
    }
}
