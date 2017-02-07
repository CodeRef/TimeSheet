using System.Web.Optimization;

namespace TimeTracker.FrontEnd
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                                      "~/Public/js/vendor/bootstrap/dist/css/bootstrap.css",
                                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Frontend-default").Include(
                                        "~/Content/templates/metronic/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                                        "~/Content/templates/metronic/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                                        "~/Content/templates/metronic/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                                        "~/Content/templates/metronic/assets/global/plugins/uniform/css/uniform.default.css"));

            bundles.Add(new StyleBundle("~/Content/Frontend-Login").Include(
                                        "~/Content/templates/metronic/assets/global/plugins/select2/select2.css",
                                        "~/Content/templates/metronic/assets/admin/pages/css/login-soft.css"));

            bundles.Add(new StyleBundle("~/Content/Frontend-theme").Include(
                                        "~/Content/templates/metronic/assets/global/css/components-rounded.css",
                                        "~/Content/templates/metronic/assets/global/css/plugins.css",
                                        "~/Content/templates/metronic/assets/admin/layout2/css/layout.css",
                                        "~/Content/templates/metronic/assets/admin/layout2/css/templates/default.css",
                                        "~/Content/templates/metronic/assets/admin/layout2/css/custom.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/Frontend-Script").Include(
                "~/Content/templates/metronic/assets/global/plugins/backstretch/jquery.backstretch.min.js"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}