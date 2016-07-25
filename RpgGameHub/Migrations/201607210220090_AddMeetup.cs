namespace RpgGameHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddMeetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meetups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GamerId = c.String(nullable: false, maxLength: 128),
                        DateTime = c.DateTime(nullable: false),
                        Details = c.String(maxLength: 250),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.GamerId, cascadeDelete: true)
                .Index(t => t.GamerId);
            
             
        }
        
        public override void Down()
        {
            DropTable("dbo.Meetups");
        }
    }
}
