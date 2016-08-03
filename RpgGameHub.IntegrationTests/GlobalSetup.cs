using NUnit.Framework;
using RpgGameHub.Core.Models;
using RpgGameHub.Persistence;
using System.Data.Entity.Migrations;
using System.Linq;

namespace RpgGameHub.IntegrationTests
{
    [SetUpFixture]
    public class GlobalSetup
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            MigrateDbToLatestVersion();
            Seed();
         }

        private static void MigrateDbToLatestVersion()
        {
            var configuration = new Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }

        public void Seed()
        {
            var context = new ApplicationDbContext();

            if (context.Users.Any())
                return;

            context.Users.Add(new ApplicationUser { UserName = "user1", Handle= "user1", Email = "-", PasswordHash = "-" });
            context.Users.Add(new ApplicationUser { UserName = "user2", Handle= "user2", Email = "+", PasswordHash = "+" });
            context.SaveChanges();

        }
    }
   }

 