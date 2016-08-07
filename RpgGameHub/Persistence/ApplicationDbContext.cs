using Microsoft.AspNet.Identity.EntityFramework;
using RpgGameHub.Core.Models;
using System.Data.Entity;

namespace RpgGameHub.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<Meetup> Meetups { get; set; }
        public DbSet<GameFan> GameFans { get; set; }
        public DbSet<RpgGameRef> RpgGameRefs { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameFan>().HasRequired(m => m.Meetup)
                .WithMany(g => g.GameFans).WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
