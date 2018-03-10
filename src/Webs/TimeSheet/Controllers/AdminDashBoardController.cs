using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimeSheet.Controllers
{
    public class AdminDashBoardController : Controller
    {
        // GET: AdminDashBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}