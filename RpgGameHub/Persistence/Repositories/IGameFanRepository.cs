using RpgGameHub.Core.Models;
using System.Collections.Generic;

namespace RpgGameHub.Persistence.Repositories
{
    public interface IGameFanRepository
    {
        bool GetGameFanAttendingMeetupFlag(int Id, string userId);
        GameFan GetGameFanSingleForMeetup(int id, string userId);
        IEnumerable<GameFan> GetAllGameFans();
        void Add(GameFan gameFan);
        void Remove(GameFan gameFan);
    }
}