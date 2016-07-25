namespace RpgGameHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMeetup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meetups", "RgpGameId", c => c.Byte(nullable: false));
            DropColumn("dbo.Meetups", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meetups", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Meetups", "RgpGameId");
        }
    }
}
