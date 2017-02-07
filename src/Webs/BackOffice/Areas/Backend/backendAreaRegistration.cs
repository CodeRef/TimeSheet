using System.Web.Mvc;

namespace RestMeet.Areas.backend
{
    public class BackendAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Backend";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "backend_default",
                "backend/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}