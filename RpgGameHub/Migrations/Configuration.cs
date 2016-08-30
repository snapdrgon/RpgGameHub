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
                new RpgGameRef { RpgGameId = (byte)RpgGameTypeEnum.DivinityOS, Url = @"http://www.divinityoriginalsin.com/" },
                new RpgGameRef { RpgGameId = (byte)RpgGameTypeEnum.Fallout, Url = @"https://www.fallout4.com/" },
                new RpgGameRef { RpgGameId = (byte)RpgGameTypeEnum.Inquisition, Url = @"https://www.dragonage.com/" },
                new RpgGameRef { RpgGameId = (byte)RpgGameTypeEnum.MassEffect, Url = @"http://masseffect.bioware.com/" },
                new RpgGameRef { RpgGameId = (byte)RpgGameTypeEnum.Skyrim, Url = @"http://www.elderscrolls.com/skyrim/" }
                );

            context.RpgGameTypes.AddOrUpdate(
                r => r.Id,
                new RpgGameType { Id = (byte)RpgGameTypeEnum.DivinityOS, Name = "Divinity Original Sin" },
                new RpgGameType { Id = (byte)RpgGameTypeEnum.Fallout, Name = "Fallout" },
                new RpgGameType { Id = (byte)RpgGameTypeEnum.Inquisition, Name = "Inquisition" },
                new RpgGameType { Id = (byte)RpgGameTypeEnum.MassEffect, Name = "MassEffect" },
                new RpgGameType { Id = (byte)RpgGameTypeEnum.Skyrim, Name = "Skyrim" }
                );

        }
    }
}
