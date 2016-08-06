namespace RpgGameHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRpgGameRefTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RpgGameRefs",
                c => new
                    {
                        RpgGameId = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.RpgGameId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RpgGameRefs");
        }
    }
}
