using System.Net.Http;
using System.Web.Http;

namespace RpgGameHub.Controllers.Api
{
    public interface IMeetupController
    {
        IHttpActionResult Cancel(int id);
        HttpResponseMessage GetMeetupDetails(int id);
    }
}