using Microsoft.AspNet.Identity;
using RpgGameHub.Persistence;
using System.Web.Http;

namespace RpgGameHub.Controllers.Api
{
    public class MeetupController : ApiController, IMeetupController
    {

        private readonly IUnitOfWork _unitOfWork;
        public MeetupController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var meetup = _unitOfWork.Meetups.GetSingleMeetupAssociatedWithGameMaster(id, userId);

            if (meetup == null || meetup.IsCancelled)
                return NotFound();

            if (meetup.GamerId != userId)
                return Unauthorized();

            meetup.Cancel();

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
