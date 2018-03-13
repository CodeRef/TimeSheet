using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimeSheet.Areas.UserProfile.Controllers
{
    public class HomeController : Controller
    {
        // GET: UserProfile/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}