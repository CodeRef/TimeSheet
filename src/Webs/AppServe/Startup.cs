using Microsoft.Owin;
using Owin;
using TimeTracker.FrontEnd;

[assembly: OwinStartup(typeof(Startup))]
namespace TimeTracker.FrontEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
