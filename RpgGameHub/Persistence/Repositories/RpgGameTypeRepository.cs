using RpgGameHub.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace RpgGameHub.Persistence.Repositories
{
    public class RpgGameTypeRepository : IRpgGameTypeRepository
    {
        private IApplicationDbContext _context;
        public RpgGameTypeRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<RpgGameType> GetGameTypes()
        {
            return _context.RpgGameTypes.Select(r => r).OrderBy(r => r.Id).ToList();
        }
    }
}