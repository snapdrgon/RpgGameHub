namespace RpgGameHub.Migrations
{
    using RpgGameHub.Core.Models;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<RpgGameHub.Persistence.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RpgGameHub.Persistence.ApplicationDbContext context)
        {
         
            context.RpgGameRefs.AddOrUpdate(
                r=>r.RpgGameId,
                new RpgGameRef { RpgGameId = (byte)RpgGameType.DivinityOS, Url = @"http://www.divinityoriginalsin.com/" },
                new RpgGameRef { RpgGameId = (byte)RpgGameType.Fallout, Url = @"https://www.fallout4.com/" },
                new RpgGameRef { RpgGameId = (byte)RpgGameType.Inquisition, Url = @"https://www.dragonage.com/" },
                new RpgGameRef { RpgGameId = (byte)RpgGameType.MassEffect, Url = @"http://masseffect.bioware.com/" },
                new RpgGameRef { RpgGameId = (byte)RpgGameType.Skyrim, Url = @"http://www.elderscrolls.com/skyrim/" }
                );

        }
    }
}
