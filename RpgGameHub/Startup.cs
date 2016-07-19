using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RpgGameHub.Startup))]
namespace RpgGameHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
