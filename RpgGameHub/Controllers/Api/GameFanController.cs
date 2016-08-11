using Microsoft.AspNet.Identity;
using RpgGameHub.Core.Models;
using RpgGameHub.Persistence;
using System.Web.Http;

namespace RpgGameHub.Controllers.Api
{
    public class GameFanController : ApiController, IGameFanController
    {
        private readonly IUnitOfWork _unitOfWork;
        public GameFanController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult AddGameFan(int id)
        {
            var userId = User.Identity.GetUserId();
            var going = _unitOfWork.GameFans.GetGameFanAttendingMeetupFlag(id, userId);

            if (going) //fan already going
                return BadRequest("GameFan already attending Meetup");

            _unitOfWork.GameFans.Add(new GameFan { GamerId = userId, MeetupId = id });
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteGameFan(int id)
        {
            var userId = User.Identity.GetUserId();

            var gameFan = _unitOfWork.GameFans.GetGameFanSingleForMeetup(id, userId);

            if (gameFan==null)
                return BadRequest("GameFan is not shown as going to the Meetup");

            _unitOfWork.GameFans.Remove(gameFan);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
