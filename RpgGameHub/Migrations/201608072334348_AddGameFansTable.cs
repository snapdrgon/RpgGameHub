namespace RpgGameHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGameFansTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameFans",
                c => new
                    {
                        MeetupId = c.Int(nullable: false),
                        GamerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MeetupId, t.GamerId })
                .ForeignKey("dbo.AspNetUsers", t => t.GamerId, cascadeDelete: true)
                .ForeignKey("dbo.Meetups", t => t.MeetupId)
                .Index(t => t.MeetupId)
                .Index(t => t.GamerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameFans", "MeetupId", "dbo.Meetups");
            DropForeignKey("dbo.GameFans", "GamerId", "dbo.AspNetUsers");
            DropIndex("dbo.GameFans", new[] { "GamerId" });
            DropIndex("dbo.GameFans", new[] { "MeetupId" });
            DropTable("dbo.GameFans");
        }
    }
}
