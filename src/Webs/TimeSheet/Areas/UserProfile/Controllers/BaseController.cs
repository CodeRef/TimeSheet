using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimeSheet.Areas.UserProfile.Controllers
{
    [Authorize(Roles = "User")]
    public class BaseController : Controller
    {
     
    }
}