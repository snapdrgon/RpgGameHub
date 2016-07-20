using System.Security.Claims;
using System.Security.Principal;

namespace RpgGameHub.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetHandle(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Handle");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}