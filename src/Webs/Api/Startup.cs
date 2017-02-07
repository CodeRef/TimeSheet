using System.Web.Http;
using Microsoft.Owin;
using Owin;
using TimeTracker.Api;

[assembly: OwinStartup(typeof(Startup))]

namespace TimeTracker.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //  ConfigureAuth(app);
            HttpConfiguration httpConfig = new HttpConfiguration();

            ConfigureOAuthTokenGeneration(app);

            ConfigureOAuthTokenConsumption(app);

            ConfigureWebApi(httpConfig);

            // Note: Cross domain does not work if you are unblock this code. I cluse with App_Start/WebApiConfig.cs >  config.EnableCors()
            // NOTE : app.UseCors(CorsOptions.AllowAll) - enables CORS for all cross-origins requests to your site.config.EnableCors(..) enables CORS for Web Api only
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseWebApi(httpConfig);
        }
    }
}