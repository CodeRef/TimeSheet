using System.Web.Mvc;

namespace TimeTracker.FrontEnd.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
    }
}