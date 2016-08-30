using System.Collections.Generic;
using RpgGameHub.Core.Models;

namespace RpgGameHub.Persistence.Repositories
{
    public interface IRpgGameTypeRepository
    {
        IEnumerable<RpgGameType> GetGameTypes();
    }
}