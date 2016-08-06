using AutoMapper;
using RpgGameHub.Core.Dtos;
using RpgGameHub.Core.Models;
using RpgGameHub.Extensions;
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
                m => m.DateTime > DateTime.Now)
                .OrderBy(m => m.DateTime).ToList();
        }

        public IEnumerable<Meetup> GetUpComingMeetupsByGameMaster(string userId)
        {
            return _context.Meetups.Where(
                m => m.DateTime > DateTime.Now && m.GamerId==userId
                &&  !m.IsCancelled).OrderBy(m => m.DateTime).ToList();
        }

        public Meetup GetSingleMeetupAssociatedWithGameMaster(int id, string userId)
        {
            var meetup = _context.Meetups.SingleOrDefault(m => m.Id == id &&
            m.GamerId==userId);
            return meetup;
        }
        public MeetupDto GetMeetupDetails(int id)
        {
            var meetup = _context.Meetups.SingleOrDefault(m => m.Id == id);
            var gameUrl = _context.RpgGameRefs.Where(g => g.RpgGameId == meetup.RgpGameId)
                .Select(g => g.Url).ToList(); //yes I know it's ugly, but it will work for now
            //intermediate step to set the RgpGameName, Date, Time and Url based on the RpgGameId
            var meetupDto = Mapper.Map<Meetup, MeetupDto>(meetup);
            meetupDto.Date = meetup.DateTime.ToString("d MMM yyyy");
            meetupDto.Time = meetup.DateTime.ToString("HH:mm");
            meetupDto.Url = gameUrl[0]; //ugly .. need to change
            meetupDto.RgpGameName = ((RpgGameType)meetup.RgpGameId).EnumDesc();
            return meetupDto;
        }

        public void Add(Meetup meetup)
        {
            _context.Meetups.Add(meetup);
        }
    }
}