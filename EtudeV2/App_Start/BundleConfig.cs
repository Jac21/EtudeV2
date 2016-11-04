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

            /* Project bundles */

            bundles.Add(new ScriptBundle("~/bundles/projectApp").Include(
                    "~/Scripts/projectApp.js",
                    "~/Scripts/Controllers/projects/projectsController.js",
                    "~/Scripts/Services/projects/projectsService.js"
                ));
            
            bundles.Add(new ScriptBundle("~/bundles/projectViewApp").Include(
                    "~/Scripts/Controllers/projects/projectViewController.js",
                    "~/Scripts/Services/projects/projectViewService.js"
                ));
            
            bundles.Add(new ScriptBundle("~/bundles/projectCreateApp").Include(
                    "~/Scripts/Controllers/projects/projectCreateController.js",
                    "~/Scripts/Services/projects/projectCreateService.js"
                ));

            /* Track bundles */

            bundles.Add(new ScriptBundle("~/bundles/trackApp").Include(
                    "~/Scripts/trackApp.js",
                    "~/Scripts/Controllers/tracks/tracksController.js",
                    "~/Scripts/Services/tracks/tracksService.js"
                ));
            
            bundles.Add(new ScriptBundle("~/bundles/trackViewApp").Include(
                    "~/Scripts/Controllers/tracks/trackViewController.js",
                    "~/Scripts/Services/tracks/trackViewService.js"
                ));
            
            bundles.Add(new ScriptBundle("~/bundles/trackCreateApp").Include(
                    "~/Scripts/Controllers/tracks/trackCreateController.js",
                    "~/Scripts/Services/tracks/trackCreateService.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/materialize.min.css",
                      "~/Content/style.css",
                      "~/Content/font-awesome.min.css"
                      ));
        }
    }
}
