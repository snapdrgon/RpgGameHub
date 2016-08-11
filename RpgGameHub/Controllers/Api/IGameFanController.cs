using System.Web.Http;

namespace RpgGameHub.Controllers.Api
{
    public interface IGameFanController
    {
        IHttpActionResult AddGameFan(int id);
        IHttpActionResult DeleteGameFan(int id);
    }
}