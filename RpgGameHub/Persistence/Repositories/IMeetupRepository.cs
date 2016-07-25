using System.Collections.Generic;
using RpgGameHub.Core.Models;

namespace RpgGameHub.Persistence.Repositories
{
    public interface IMeetupRepository
    {
        void Add(Meetup meetup);
        IEnumerable<Meetup> GetUpComingMeetups();
    }
}