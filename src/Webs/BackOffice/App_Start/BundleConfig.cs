using System.Web.Optimization;

namespace RestMeet
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            #region Create by Fouk

            bundles.Add(new ScriptBundle("~/bundles/layout").Include(
                "~/Content/themes/metronic/assets/global/plugins/jquery-1.11.0.min.js",
                "~/Content/themes/metronic/assets/global/plugins/jquery-migrate-1.2.1.min.js",
                "~/Content/themes/metronic/assets/global/plugins/jquery-ui/jquery-ui-1.10.3.custom.min.js",
                "~/Content/themes/metronic/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                "~/Content/themes/metronic/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
                "~/Content/themes/metronic/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/Content/themes/metronic/assets/global/plugins/jquery.blockui.min.js",
                "~/Content/themes/metronic/assets/global/plugins/jquery.cokie.min.js",
                "~/Content/themes/metronic/assets/global/plugins/uniform/jquery.uniform.min.js",
                "~/Content/themes/metronic/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js",
                "~/Content/themes/metronic/assets/global/plugins/flot/jquery.flot.min.js",
                "~/Content/themes/metronic/assets/global/plugins/flot/jquery.flot.resize.min.js",
                "~/Content/themes/metronic/assets/global/plugins/flot/jquery.flot.categories.min.js",
                "~/Content/themes/metronic/assets/global/plugins/jquery.pulsate.min.js",
                "~/Content/themes/metronic/assets/global/plugins/bootstrap-daterangepicker/moment.min.js",
                "~/Content/themes/metronic/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.js",
                "~/Content/themes/metronic/assets/global/plugins/fullcalendar/fullcalendar/fullcalendar.min.js",
                "~/Content/themes/metronic/assets/global/plugins/jquery-easypiechart/jquery.easypiechart.min.js",
                "~/Content/themes/metronic/assets/global/plugins/jquery.sparkline.min.js",
                "~/Content/themes/metronic/assets/global/plugins/gritter/js/jquery.gritter.js",
                "~/Content/themes/metronic/assets/global/scripts/metronic.js",
                "~/Content/themes/metronic/assets/admin/layout/scripts/layout.js",
                "~/Content/themes/metronic/assets/admin/layout/scripts/quick-sidebar.js"
                ));

            bundles.Add(new StyleBundle("~/Content/layout").Include(

                "~/Content/themes/metronic/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                "~/Content/themes/metronic/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                "~/Content/themes/metronic/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                "~/Content/themes/metronic/assets/global/plugins/uniform/css/uniform.default.css",
                "~/Content/themes/metronic/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css",
                "~/Content/themes/metronic/assets/global/plugins/gritter/css/jquery.gritter.css",
                "~/Content/themes/metronic/assets/global/plugins/bootstrap-daterangepicker/daterangepicker-bs3.css",
                "~/Content/themes/metronic/assets/global/plugins/fullcalendar/fullcalendar/fullcalendar.css",
                "~/Content/themes/metronic/assets/global/plugins/jqvmap/jqvmap/jqvmap.css",
                "~/Content/themes/metronic/assets/admin/pages/css/tasks.css",
                "~/Content/themes/metronic/assets/global/css/components.css",
                "~/Content/themes/metronic/assets/global/css/plugins.css",
                "~/Content/themes/metronic/assets/admin/layout/css/layout.css",
                "~/Content/themes/metronic/assets/admin/layout/css/themes/default.css",
                "~/Content/themes/metronic/assets/admin/layout/css/custom.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/page-login").Include(
                "~/Content/themes/metronic/assets/global/plugins/jquery-validation/js/jquery.validate.min.js",
                "~/Content/themes/metronic/assets/global/plugins/select2/select2.min.js",
                "~/Content/themes/metronic/assets/admin/pages/scripts/login.js"
            ));

            bundles.Add(new StyleBundle("~/Content/login").Include(
                "~/Content/themes/metronic/assets/global/plugins/select2/select2.css",
                "~/Content/themes/metronic/assets/admin/pages/css/login.css"
            ));

            bundles.Add(new StyleBundle("~/Content/page-profile").Include(
                 "~/Content/themes/metronic/assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.css",
                 "~/Content/themes/metronic/assets/admin/pages/css/profile.css"
            ));

            bundles.Add(new StyleBundle("~/Content/crop").Include(
                 "~/Content/themes/metronic/assets/global/plugins/jcrop/css/jquery.Jcrop.min.css",
                 "~/Content/themes/metronic/assets/admin/pages/css/image-crop.css"
            //"~/content/css/Jcrop/jquery.Jcrop.min.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/crop").Include(
                "~/Content/themes/metronic/assets/global/plugins/jcrop/js/jquery.color.js",
                "~/Content/themes/metronic/assets/global/plugins/jcrop/js/jquery.Jcrop.min.js",
                "~/Content/themes/metronic/assets/global/scripts/metronic.js",
                "~/Content/themes/metronic/assets/admin/layout/scripts/layout.js",
                "~/Content/themes/metronic/assets/admin/layout/scripts/quick-sidebar.js",
                "~/Content/themes/metronic/assets/admin/layout/scripts/demo.js",
                "~/Content/themes/metronic/assets/admin/pages/scripts/form-image-crop.js"
                //"~/Scripts/Jcrop/js/jquery.Jcrop.js"
                ));

            #endregion Create by Fouk

            #region Frontend-Corporate

            bundles.Add(new ScriptBundle("~/bundles/Corporate-Core").Include(
                          "~/Content/themes/metronic/assets/global/plugins/jquery-1.11.0.min.js",
                          "~/Content/themes/metronic/assets/global/plugins/jquery-migrate-1.2.1.min.js",
                          "~/Content/themes/metronic/assets/global/plugins/bootstrap/js/bootstrap.min.js"
                          ));
            bundles.Add(new ScriptBundle("~/bundles/Corporate-Plugin-Revo").Include(
                          "~/Content/themes/metronic/assets/global/plugins/slider-revolution-slider/rs-plugin/js/jquery.themepunch.plugins.min.js",
                          "~/Content/themes/metronic/assets/global/plugins/slider-revolution-slider/rs-plugin/js/jquery.themepunch.revolution.min.js",
                          "~/Content/themes/metronic/assets/global/plugins/slider-revolution-slider/rs-plugin/js/jquery.themepunch.tools.min.js",
                          "~/Content/themes/metronic/assets/frontend/onepage/scripts/revo-ini.js"
                          ));

            bundles.Add(new ScriptBundle("~/bundles/Corporate-Plugin-Core").Include(
                          "~/Content/themes/metronic/assets/global/plugins/fancybox/source/jquery.fancybox.pack.js",
                          "~/Content/themes/metronic/assets/global/plugins/jquery.easing.js",
                          "~/Content/themes/metronic/assets/global/plugins/jquery.parallax.js",
                          "~/Content/themes/metronic/assets/global/plugins/jquery.scrollTo.min.js",
                          "~/Content/themes/metronic/assets/frontend/onepage/scripts/jquery.nav.js"
                          ));

            bundles.Add(new ScriptBundle("~/bundles/Corporate-Page").Include(
              "~/Content/themes/metronic/assets/frontend/onepage/scripts/layout.js"));

            bundles.Add(new StyleBundle("~/Content/Corporate-Global").Include(
                "~/Content/themes/metronic/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                "~/Content/themes/metronic/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                "~/Content/themes/metronic/assets/global/plugins/slider-revolution-slider/rs-plugin/css/settings.css"
            ));

            bundles.Add(new StyleBundle("~/Content/Corporate-plugin").Include("~/Content/themes/metronic/assets/global/plugins/fancybox/source/jquery.fancybox.css"));

            bundles.Add(new StyleBundle("~/Content/Corporate-Theme").Include(
         "~/Content/themes/metronic/assets/global/css/components.css",
         "~/Content/themes/metronic/assets/frontend/onepage/css/style.css",
         "~/Content/themes/metronic/assets/frontend/onepage/css/style-responsive.csss",
         "~/Content/themes/metronic/assets/frontend/onepage/css/themes/green.css",// blue,gray,green,orange,red,turquoise
         "~/Content/themes/metronic/assets/frontend/onepage/css/custom.css"));

            #endregion Frontend-Corporate

            #region Frontend-Login-Register

            bundles.Add(new ScriptBundle("~/bundles/Frontend-Global").Include(
"~/Content/themes/metronic/assets/global/plugins/jquery-1.11.0.min.js",
"~/Content/themes/metronic/assets/global/plugins/jquery-migrate-1.2.1.min.js",
"~/Content/themes/metronic/assets/global/plugins/jquery-ui/jquery-ui-1.10.3.custom.min.js",
"~/Content/themes/metronic/assets/global/plugins/bootstrap/js/bootstrap.min.js",
"~/Content/themes/metronic/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
"~/Content/themes/metronic/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
"~/Content/themes/metronic/assets/global/plugins/jquery.blockui.min.js",
"~/Content/themes/metronic/assets/global/plugins/jquery.cokie.min.js",
"~/Content/themes/metronic/assets/global/plugins/uniform/jquery.uniform.min.js",
"~/Content/themes/metronic/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js"
));
            bundles.Add(new ScriptBundle("~/bundles/Frontend-Plugin").Include(
"~/Content/themes/metronic/assets/global/plugins/jquery-validation/js/jquery.validate.min.js",
"~/Content/themes/metronic/assets/global/plugins/backstretch/jquery.backstretch.min.js",
"~/Content/themes/metronic/assets/global/plugins/select2/select2.min.js"
));

            bundles.Add(new ScriptBundle("~/bundles/Frontend-Script").Include(
"~/Content/themes/metronic/assets/global/scripts/metronic.js",
//"~/Content/themes/metronic/assets/admin/layout2/scripts/layout.js",
//"~/Content/themes/metronic/assets/admin/layout2/scripts/demo.js",
"~/Content/themes/metronic/assets/admin/pages/scripts/login-soft.js",
"~/Content/themes/metronic/assets/admin/pages/scripts/lock.js"
));

            bundles.Add(new StyleBundle("~/Content/Frontend-default").Include(
"~/Content/themes/metronic/assets/global/plugins/font-awesome/css/font-awesome.min.css",
"~/Content/themes/metronic/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
"~/Content/themes/metronic/assets/global/plugins/bootstrap/css/bootstrap.min.css",
"~/Content/themes/metronic/assets/global/plugins/uniform/css/uniform.default.css"));

            bundles.Add(new StyleBundle("~/Content/Frontend-Login").Include(
"~/Content/themes/metronic/assets/global/plugins/select2/select2.css",
"~/Content/themes/metronic/assets/admin/pages/css/login-soft.css"));

            bundles.Add(new StyleBundle("~/Content/Frontend-Lock").Include(
"~/Content/themes/metronic/assets/admin/pages/css/lock2.css"));

            bundles.Add(new StyleBundle("~/Content/Frontend-theme").Include(
"~/Content/themes/metronic/assets/global/css/components-rounded.css",
"~/Content/themes/metronic/assets/global/css/plugins.css",
"~/Content/themes/metronic/assets/admin/layout2/css/layout.css",
"~/Content/themes/metronic/assets/admin/layout2/css/themes/default.css",
"~/Content/themes/metronic/assets/admin/layout2/css/custom.css"
                ));

            #endregion Frontend-Login-Register

            #region FrontEnd-TimeLine

            bundles.Add(new StyleBundle("~/Content/Frontend-TimeLine").Include(
"~/Content/themes/metronic/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css",
"~/Content/themes/metronic/assets/admin/pages/css/timeline.css",
"~/Content/themes/metronic/assets/global/css/plugins.css",
"~/Content/themes/metronic/assets/admin/layout/css/layout.css",
"~/Content/themes/metronic/assets/admin/layout/css/themes/darkblue.css",
"~/Content/themes/metronic/assets/admin/layout/css/custom.css"
));

            #endregion FrontEnd-TimeLine

            BundleTable.EnableOptimizations = false;
        }
    }
}