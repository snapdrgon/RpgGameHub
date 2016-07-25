using System.Data.Entity;
using RpgGameHub.Core.Models;

namespace RpgGameHub.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Meetup> Meetups { get; set; }
        int SaveChanges();
  }

}