namespace RpgGameHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRpgGameTypesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RpgGameTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RpgGameTypes");
        }
    }
}
