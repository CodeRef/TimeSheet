using System;
using System.Configuration;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Owin;
using TimeTracker.Api.Providers;
using TimeTracker.Model;

namespace TimeTracker.Api
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        //// For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        //public void ConfigureAuth(IAppBuilder app)
        //{
        //    // Configure the db context and user manager to use a single instance per request
        //    app.CreatePerOwinContext(RestMeetContext.Create);
        //    app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

        //    // Enable the application to use a cookie to store information for the signed in user
        //    // and to use a cookie to temporarily store information about a user logging in with a third party login provider
        //    app.UseCookieAuthentication(new CookieAuthenticationOptions());
        //    app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

        //    // Configure the application for OAuth based flow
        //    PublicClientId = "self";
        //    OAuthOptions = new OAuthAuthorizationServerOptions
        //    {
        //        TokenEndpointPath = new PathString("/Token"),
        //        Provider = new ApplicationOAuthProvider(PublicClientId),
        //        AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
        //        AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
        //        AllowInsecureHttp = true
        //    };

        //    // Enable the application to use bearer tokens to authenticate users
        //    app.UseOAuthBearerTokens(OAuthOptions);

        //    // Uncomment the following lines to enable logging in with third party login providers
        //    //app.UseMicrosoftAccountAuthentication(
        //    //    clientId: "",
        //    //    clientSecret: "");

        //    //app.UseTwitterAuthentication(
        //    //    consumerKey: "",
        //    //    consumerSecret: "");

        //    //app.UseFacebookAuthentication(
        //    //    appId: "",
        //    //    appSecret: "");

        //    //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
        //    //{
        //    //    ClientId = "",
        //    //    ClientSecret = ""
        //    //});
        //}

        private void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(DataContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat("http://localhost:31832")
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
        }

        private void ConfigureOAuthTokenConsumption(IAppBuilder app)
        {
            var issuer = "http://localhost:31832";
            string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["as:AudienceSecret"]);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audienceId },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
                    }
                });
        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}