using RpgGameHub.Core.Dtos;
using RpgGameHub.Core.Models;
using System.Collections.Generic;

namespace RpgGameHub.Persistence.Repositories
{
    public interface IMeetupRepository
    {
        void Add(Meetup meetup);

        IEnumerable<Meetup> GetUpComingMeetups();

        IEnumerable<Meetup> GetUpComingMeetupsByGameMaster(string userId);
        Meetup GetSingleMeetupAssociatedWithGameMaster(int id, string userId);

        MeetupDto GetMeetupDetails(int id);
    }
}