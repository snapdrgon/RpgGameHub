using RpgGameHub.Persistence;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RpgGameHub.Controllers.Api
{
    [Authorize]
    public class RpgGameTypeController : ApiController, IRpgGameTypeController
    {
        private readonly IUnitOfWork _unitOfWork;
        public RpgGameTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;     
        }

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetRpgGameRefTypes()
        {
            var gameRef = _unitOfWork.RpgGameTypes.GetGameTypes();

            HttpResponseMessage response;

            if (gameRef == null)
                response = Request.CreateResponse(HttpStatusCode.NotFound, gameRef);
            else
                response = Request.CreateResponse(HttpStatusCode.OK, gameRef);

            return response; //jump out
        }
    }
}
