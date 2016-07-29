using RpgGameHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RpgGameHub.Persistence.Repositories
{
    public class MeetupRepository : IMeetupRepository
    {
        private readonly IApplicationDbContext _context;

        public MeetupRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Meetup> GetUpComingMeetups()
        {
            return _context.Meetups.Where(
                m => m.DateTime > DateTime.Now
                && !m.IsCancelled).OrderBy(m=>m.DateTime)
                .ToList();
        }

        public void Add(Meetup meetup)
        {
            _context.Meetups.Add(meetup);
        }
    }
}