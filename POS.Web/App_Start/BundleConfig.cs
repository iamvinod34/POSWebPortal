using System.Web;
using System.Web.Optimization;

namespace POS.Web
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
                      "~/Scripts/respond.js"
                      ));

            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                "~/Scripts/jquery-ui-1.12.0.js",
                 "~/Scripts/MasterValidation.js",
                  "~/Scripts/superfish.js",
                        "~/Scripts/button.js",
                        "~/Scripts/camera.js",
                        "~/Scripts/carousel.js",
                        "~/Scripts/collapse.js",
                        "~/Scripts/device.min.js",
                        "~/Scripts/dropdown.js",
                        "~/Scripts/jquery-migrate-1.2.1.min.js",
                        "~/Scripts/jquery.cookie.js",
                        "~/Scripts/jquery.easing.1.3.js",
                        "~/Scripts/jquery.equalheights.js",
                        //"~/Scripts/jquery.js",
                        //"~/Scripts/jquery.mobile.customized.min.js",
                        "~/Scripts/jquery.mobilemenu.js",
                        "~/Scripts/jquery.rd-google-map.js",
                        "~/Scripts/modal.js",
                        "~/Scripts/MasterValidation.js",
                        "~/Scripts/jquery.ui.totop.js",
                        "~/Scripts/scrollspy.js",
                        //"~/Scripts/TMSearch.js",
                        //"~/Scripts/mailform/jquery.form.min.js",
                        //"~/Scripts/mailform/jquery.rd-mailform.min.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/device.min.js",
                       "~/Scripts/jquery.unobtrusive-ajax.js",
                        //"~/Scripts/tm-scripts.js"
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/bootstrap-dialog.js"

                        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap.css",
                        "~/Content/camera.css",
                        "~/Content/owl-carousel.css",
                        "~/Content/jquery.fancybox.css",
                        "~/Content/search.css",
                        "~/Content/animate.css",
                        "~/Content/google-map.css",
                        "~/Content/style.css",
                        "~/Content/thumbnails.css",
                        "~/Content/variables.css",
                        "~/Content/bootstrap-dialog.css",
                        "~/Content/bootstrap-dialog.less"
                        
                      ));
            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                 "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"
                ));
        }
    }
}
