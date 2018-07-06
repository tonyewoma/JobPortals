using System.Web;
using System.Web.Optimization;

namespace JobPortals
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
                      "~/Scripts/bootbox.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/site.css"));

            //Admin
            bundles.Add(new ScriptBundle("~/bundles/admin/js").Include(
                        "~/plugins/jQuery/jQuery-2.2.0.min.js",
                        "~/bootstrap/js/bootstrap.min.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/jquery-{version}.js",
                        "~/dist/js/app.min.js",
                        "~/scripts/datatables/jquery.datatables.js",
                        "~/scripts/datatables/datatables.bootstrap.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/admin/css").Include(
                      "~/bootstrap/css/bootstrap.min.css",
                      "~/dist/css/AdminLTE.min.css",
                      "~/Areas/Administrator/Content/site.css",
                      "~/dist/css/skins/skin-blue.min.css",
                       "~/content/datatables/css/datatables.bootstrap.css"
                       ));
        }
    }
}
