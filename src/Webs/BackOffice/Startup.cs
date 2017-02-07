using Microsoft.Owin;
using Owin;
using RestMeet;

[assembly: OwinStartup(typeof (Startup))]

namespace RestMeet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}