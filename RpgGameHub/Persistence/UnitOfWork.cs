using RpgGameHub.Persistence.Repositories;

namespace RpgGameHub.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;

        public IMeetupRepository Meetups { get; private set; }
 
        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
            Meetups = new MeetupRepository(_context);
         }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}