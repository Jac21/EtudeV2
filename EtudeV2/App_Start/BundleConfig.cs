using System.Web;
using System.Web.Optimization;

namespace EtudeV2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/materialize").Include(
                    "~/Scripts/Materialize/materialize.min.js",
                    "~/Scripts/Materialize/forms.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                    "~/Scripts/angular.min.js",
                    "~/Scripts/angular-resource.min.js",
                    "~/Scripts/angular-route.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/projectApp").Include(
                    "~/Scripts/projectApp.js",
                    "~/Scripts/Controllers/projectsController.js",
                    "~/Scripts/Services/projectsService.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/trackApp").Include(
                    "~/Scripts/trackApp.js",
                    "~/Scripts/Controllers/tracksController.js",
                    "~/Scripts/Services/tracksService.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/materialize.min.css",
                      "~/Content/style.css",
                      "~/Content/font-awesome.min.css"
                      ));
        }
    }
}
