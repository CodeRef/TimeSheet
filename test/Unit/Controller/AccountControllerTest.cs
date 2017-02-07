
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Moq;
using RestMeet.Areas.Backend.Controllers;
using RestMeet.Controllers;
using RestMeet.Model;
using RestMeet.Test.Helpers;
using RestMeet.ViewModels;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Xunit;
namespace RestMeet.Test.Controller
{
    [Trait("Unit test for account contrller.","")]
    public class AccountControllerTest
    {
        Mock<ControllerContext> controllerContext;
        Mock<IIdentity> identity;
        Mock<IPrincipal> principal;
        //Mock<HttpContext> httpContext;
        //Mock<HttpContextBase> contextBase;
        //Mock<HttpRequestBase> httpRequest;
        //Mock<HttpResponseBase> httpResponse;
        Mock<HttpSessionStateBase> httpSession;
        //Mock<GenericPrincipal> genericPrincipal;
        public AccountControllerTest()
        {
            controllerContext = new Mock<ControllerContext>();
            identity = new Mock<IIdentity>();
            principal = new Mock<IPrincipal>();
            //httpContext = new Mock<HttpContext>();
            //contextBase = new Mock<HttpContextBase>();
            //httpRequest = new Mock<HttpRequestBase>();
            //httpResponse = new Mock<HttpResponseBase>();
            httpSession = new Mock<HttpSessionStateBase>();
            //genericPrincipal = new Mock<GenericPrincipal>();
        }
        //[Fact]
        //public void Login_Get_View_If_Guid_Is_Null()
        //{
        //    var userManager = new UserManager<ApplicationUser>(new TestUserStore());
        //    // Guid goalIdToken = Guid.NewGuid();
        //    controllerContext.SetupGet(p => p.HttpContext.Request.QueryString).Returns(new NameValueCollection());
        //    //AccountController controller = new AccountController(userService, userProfileService, goalService, updateService, commentService, followRequestService, followUserService, securityTokenService, userManager);
        //    var controller = new AccountController(userManager);
        //    controller.ControllerContext = controllerContext.Object;
        //    ViewResult rslt = controller.Login("abcd") as ViewResult;
        //    Assert.NotNull(rslt);
        //}

        //[Fact(DisplayName="Login controller will return View object when we pass not null object.")]
        //public void Login_Get_View_If_Guid_Is_NotNull()
        //{
        //    var userManager = new UserManager<ApplicationUser>(new TestUserStore());
        //    //mocking QueryString
        //    var querystring = new NameValueCollection { { "guid", "got_value" } };
        //    var querystring1 = new NameValueCollection { { "reg", "value" } };
        //    Guid goalIdToken = Guid.NewGuid();
        //    // Guid 
        //    controllerContext.SetupGet(p => p.HttpContext.Request.QueryString).Returns(querystring);
        //    //controllerContext.SetupGet(p => p.HttpContext.Request.QueryString).Returns(querystring1);
        //    controllerContext.SetupGet(p => p.HttpContext.Session).Returns(httpSession.Object);
        //    // : WUT --> AccountController controller = new AccountController(userService, userProfileService, goalService, updateService, commentService, followRequestService, followUserService, securityTokenService, userManager);
        //    var controller = new AccountController(userManager);
        //    controller.ControllerContext = controllerContext.Object;

        //    var httprequest = new HttpRequest("", "http://localhost/", "");
        //    var stringWriter = new StringWriter();
        //    var httpResponce = new HttpResponse(stringWriter);
        //    var httpContext = new HttpContext(httprequest, httpResponce);
        //    // Mocking HttpContext.Current
        //    var sessionContainer = new HttpSessionStateContainer("id",
        //                            new SessionStateItemCollection(),
        //                            new HttpStaticObjectsCollection(),
        //                            10,
        //                            true,
        //                            HttpCookieMode.AutoDetect,
        //                            SessionStateMode.InProc,
        //                            false);

        //    httpContext.Items["AspSession"] = typeof(HttpSessionState).GetConstructor(
        //                BindingFlags.NonPublic | BindingFlags.Instance,
        //                null, CallingConventions.Standard,
        //                new[] { typeof(HttpSessionStateContainer) },
        //                null)
        //                .Invoke(new object[] { sessionContainer });

        //    HttpContext.Current = httpContext;

        //    ViewResult rslt = controller.Login("abcd") as ViewResult;
        //    Assert.NotNull(rslt);
        //}
        [Fact]
        public void LoginTest()
        {
            var userManager = new UserManager<ApplicationUser>(new TestUserStore());

            //  AccountController controller = new AccountController(userService, userProfileService, goalService, updateService, commentService, followRequestService, followUserService, securityTokenService, userManager);
            var controller = new AccountController(userManager);
            var mockAuthenticationManager = new Mock<IAuthenticationManager>();
            mockAuthenticationManager.Setup(am => am.SignOut());
            mockAuthenticationManager.Setup(am => am.SignIn());
            controller.AuthenticationManager = mockAuthenticationManager.Object;
            ApplicationUser applicationUser = getApplicationUser();
            userManager.CreateAsync(applicationUser, "123456");
            var result = controller.Login(new Login { UserName = "adarsh", Password = "123456", RememberMe = false }, "abcd").Result;
            Assert.NotNull(result);
            var addedUser = userManager.FindByName("adarsh");
            Assert.NotNull(addedUser);
            Assert.Equal("adarsh", addedUser.UserName);
        }


        public ApplicationUser getApplicationUser()
        {
            ApplicationUser applicationUser = new ApplicationUser()
            {
                //Activated = true,
                Email = "adarsh@foo.com",
                FirstName = "Adarsh",
                //LastName = "Vikraman",
                UserName = "adarsh",
                //RoleId = 0,
                Id = "402bd590-fdc7-49ad-9728-40efbfe512ec",
                //DateCreated = DateTime.Now,
                //LastLoginTime = DateTime.Now,
                //ProfilePicUrl = null,
            };
            return applicationUser;
        }
    }
}
