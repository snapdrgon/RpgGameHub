using RpgGameHub.Core.Models;
using System.Data.Entity;

namespace RpgGameHub.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Meetup> Meetups { get; set; }
        DbSet<RpgGameRef> RpgGameRefs { get; set; }
        int SaveChanges();
  }

}