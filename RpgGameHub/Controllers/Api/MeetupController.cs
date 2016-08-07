using Microsoft.AspNet.Identity;
using RpgGameHub.Persistence;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RpgGameHub.Controllers.Api
{
    [Authorize]
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

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetMeetupDetails(int id)
        {
            var meetup = _unitOfWork.Meetups.GetMeetupDetails(id);
            HttpResponseMessage response;

            if (meetup == null)
                response = Request.CreateResponse(HttpStatusCode.NotFound, meetup);
            else
                response = Request.CreateResponse(HttpStatusCode.OK, meetup);

            return response; //jump out

        }
    }
}
