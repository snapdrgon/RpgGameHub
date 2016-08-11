using RpgGameHub.Persistence.Repositories;

namespace RpgGameHub.Persistence
{
    public interface IUnitOfWork
    {
        IMeetupRepository Meetups { get; }
        IGameFanRepository GameFans { get; set; }

        void Complete();
    }
}