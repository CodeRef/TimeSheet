using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracker.Model;

namespace TimeSheet.Areas.Admin.Controllers
{
    public class ProjectController : BaseController
    {
        // GET: Admin/Project
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create() {
            return View();
        }
        public ActionResult Details(int id) {
            return View();
        }
        public ActionResult Edit(Project project) {
            return View();
        }
        public ActionResult Delete(int id) {
            return View();
        }
    }
}