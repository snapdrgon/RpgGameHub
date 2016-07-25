namespace RpgGameHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHandle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Handle", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Handle");
        }
    }
}
