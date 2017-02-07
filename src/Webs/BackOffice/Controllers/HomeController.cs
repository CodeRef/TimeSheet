using RestMeet.Areas.Backend.Controllers;
using RestMeet.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RestMeet.Controllers
{
    [AllowAnonymous]
    public class HomeController : AccountController
    {

        // GET: Home
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated) {
                return RedirectToAction("Home", "TimeLine");
            }
            return View();

        }

        public ActionResult Register()
        {
            return PartialView();
        }

        public ActionResult ForgetPassword()
        {
            return PartialView();
        }

        public ActionResult Login()
        {
            return PartialView();
        }
        public ActionResult Registered()
        {
            return View();
        }
        public async Task<ActionResult> ResetPassword(string userId = "", string code = "")
        {
            if (code == null) { return View("Error"); }
            else
            {
                var user = await UserManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return View("Error");
                }
                return View(new ResetPassword { ApplicateionUser = user, Code = code });
            }
        }
        public async Task<ActionResult> Timeline() {
            if (!User.Identity.IsAuthenticated) {
                return RedirectToAction("Home", "Index");
            }
            return View();
        }
    }
}