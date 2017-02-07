using System.IO;
using System.Text;
using System.Web.Mvc;

namespace TimeTracker.FrontEnd.Helpers
{
    public static class RequireHelpers
    {
        public static MvcHtmlString RequireJsScript(this UrlHelper url, string requireJs, string relativeUrl)
        {
            var file = url.RequestContext.HttpContext.Server.MapPath(relativeUrl);
            var noExtension = Path.GetFileNameWithoutExtension(file);
            var extension = Path.GetExtension(file);
            var path = Path.GetDirectoryName(relativeUrl).Replace("\\", "/");
            TagBuilder tb = new TagBuilder("script");
            tb.Attributes.Add("src", requireJs);
            tb.Attributes.Add("data-main", path + '/' + GetRegularOrMinified(noExtension, extension));
            return new MvcHtmlString(tb.ToString());
        }

        private static string GetRegularOrMinified(string noExtension, string extension)
        {
#if DEBUG
            return $"{noExtension}{extension}";
#else
            return string.Format("{0}.min{1}", noExtension, extension);
#endif
        }

        /// <summary>
        /// An Html helper for Require.js
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="core">Location of the common js file.</param>
        /// <param name="module">Location of the main.js file.</param>
        /// <returns></returns>
        public static MvcHtmlString RequireJs(this HtmlHelper helper, string core, string module)
        {
            var virtualDirectory = helper.ViewContext.HttpContext.Request.ApplicationPath;
            var require = new StringBuilder();
            var jsLocation = "/public/release/";
#if DEBUG
            jsLocation = "/public/js/";
#endif

            if (File.Exists(helper.ViewContext.HttpContext.Server.MapPath(Path.Combine(jsLocation, module + ".js"))))
            {
                require.AppendLine("require( [ \"" + jsLocation + core + "\" ], function() {");
                require.AppendLine("    require( [ \"" + module + "\"] );");
                require.AppendLine("});");
            }
            else
            {
                require.AppendLine("require( [ \"" + jsLocation + core + "\" ], function() {");
                require.AppendLine("    require( [ \"jquery\", \"bootstrap\" ] );");
                require.AppendLine("});");
            }

            return new MvcHtmlString(require.ToString());
        }

        public static MvcHtmlString ViewSpecificRequireJs(this HtmlHelper helper)
        {
            var action = helper.ViewContext.RouteData.Values["action"];

            var controller = helper.ViewContext.RouteData.Values["controller"];

            // core.js
            return helper.RequireJs("config.js", $"views/{controller}/{action}");
        }
    }
}