using RpgGameHub.Persistence.Repositories;

namespace RpgGameHub.Persistence
{
    public interface IUnitOfWork
    {
        IMeetupRepository Meetups { get; }

        void Complete();
    }
}