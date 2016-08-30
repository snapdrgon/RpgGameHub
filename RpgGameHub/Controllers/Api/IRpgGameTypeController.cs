using System.Net.Http;

namespace RpgGameHub.Controllers.Api
{
    public interface IRpgGameTypeController
    {
        HttpResponseMessage GetRpgGameRefTypes();
    }
}