using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TimeSheet.Helpers;

namespace TimeSheet.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Redirect the user to a specific URL, as specified in the web.config, depending on their role.
        /// If a user belongs to multiple roles, the first matching role in the web.config is used.
        /// Prioritize the role list by listing higher-level roles at the top.
        /// </summary>
        /// <param name="username">Username to check the roles for</param>
        private void RedirectLogin(string username)
        {
            LoginRedirectByRoleSection roleRedirectSection = (LoginRedirectByRoleSection)ConfigurationManager.GetSection("loginRedirectByRole");
            foreach (RoleRedirect roleRedirect in roleRedirectSection.RoleRedirects)
            {
                //if (Roles.IsUserInRole(username, roleRedirect.Role))
                //{
                //    Response.Redirect(roleRedirect.Url);
                //}
            }
        }
        public ActionResult Index()
        {
            var _userId = User.Identity.GetUserId();//User.Identity.IsAuthenticated ? "" : "";
            var isUserRole = User.IsInRole("User");

            LoginRedirectByRoleSection roleRedirectSection = (LoginRedirectByRoleSection)ConfigurationManager.GetSection("loginRedirectByRole");
            foreach (RoleRedirect roleRedirect in roleRedirectSection.RoleRedirects)
            {
                if (User.IsInRole(roleRedirect.Role))
                {
                    return RedirectToAction("Index", roleRedirect.Controller, new { area = roleRedirect.Area });
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}