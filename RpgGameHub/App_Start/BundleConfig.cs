using System.Web.Optimization;

namespace RpgGameHub
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                     "~/Scripts/app/app.js",
                      "~/Scripts/app/rpggamehub.js",
                     "~/Scripts/app/controllers/meetupcontroller.js",
                     "~/Scripts/app/controllers/gamefancontroller.js",
                     "~/Scripts/app/controllers/rpggametypecontroller.js"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.min.js",
                         "~/Scripts/respond.js",
                        "~/Scripts/bootbox.min.js",
                        "~/Scripts/angular.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-theme.css",
                      "~/Content/bootstrap-theme.css.map",
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.css.map",
                      "~/Content/site.css"));
        }
    }
}
