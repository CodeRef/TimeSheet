using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TimeTracker.Api.Models;

namespace TimeTracker.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        private ModelFactory _modelFactory;
        private readonly ApplicationUserManager _appUserManager = null;
        private readonly ApplicationRoleManager _appRoleManager = null;

        protected ApplicationUserManager AppUserManager => _appUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
        protected ApplicationRoleManager AppRoleManager => _appRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
        protected ModelFactory TheModelFactory => _modelFactory ?? (_modelFactory = new ModelFactory(this.Request, this.AppUserManager));

        protected BaseApiController()
        {
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}