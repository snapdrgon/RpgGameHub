using RpgGameHub.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace RpgGameHub.Persistence.Repositories
{
    public class GameFanRepository : IGameFanRepository
    {
        private IApplicationDbContext _context;

        public GameFanRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public bool GetGameFanAttendingMeetupFlag(int Id, string userId)
        {
            return  _context.GameFans.Any(g => g.MeetupId == Id
            && g.GamerId == userId);

        }

        public GameFan GetGameFanSingleForMeetup(int id, string userId)
        {
            return  _context.GameFans.SingleOrDefault(g => g.GamerId == userId
            && g.MeetupId == id);
        }

        public IEnumerable<GameFan> GetAllGameFans()
        {
            return _context.GameFans.Select(p => p)
                .OrderBy(p => p.MeetupId).ToList();
         
        }
        public void Add(GameFan gameFan)
        {
            _context.GameFans.Add(gameFan);
        }
        public void Remove(GameFan gameFan)
        {
            _context.GameFans.Remove(gameFan);
        }
    }
}