using System;
using System.Web.Optimization;

namespace People.Web.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Style Bundles

            var homeStyles = new StyleBundle("~/bundles/main/css")
                .Include("~/Content/style.css", new CssRewriteUrlTransform());

            var animateStyles = new StyleBundle("~/bundles/animate/css")
                .Include("~/Content/animate.min.css", new CssRewriteUrlTransform());

            var bootstrapStyles = new StyleBundle("~/bundles/bootstrap/css")
                .Include("~/Content/bootstrap.min.css", new CssRewriteUrlTransform());

            var fontAwesomeStyles = new StyleBundle("~/bundles/font-awesome/css")
                .Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform());

            var materialKitStyles = new StyleBundle("~/bundles/material-kit/css")
                .Include("~/Assets/css/material-kit", new CssRewriteUrlTransform());

            var pe7iconStyles = new StyleBundle("~/bundles/peicon7stroke/css")
                .Include("~/Content/pe-icons/pe-icon-7-stroke.css",
                         "~/Content/pe-icons/helper.css",
                         "~/Content/stroke-icons/style.css");

            // Adding Styles

            bundles.Add(homeStyles);
            bundles.Add(animateStyles);
            bundles.Add(bootstrapStyles);
            bundles.Add(fontAwesomeStyles);
            bundles.Add(materialKitStyles);
            bundles.Add(pe7iconStyles);

            //-----------------------------//-----------------------------//-----------------------------//-----------------------------//-----------------------------//

            // Script Bundles

            var bootstrapScripts = new ScriptBundle("~/bundles/bootstrap/js")
                .Include("~/Scripts/bootstrap.min.js");

            var jQueryScripts = new ScriptBundle("~/bundles/jquery/js")
                .Include("~/Scripts/jquery-3.3.1.min.js");

            var jQueryValidationScripts = new ScriptBundle("~/bundles/jquery-validation/js")
                .Include("~/Scripts/jquery.validate.min.js");

            var paceScripts = new ScriptBundle("~/bundles/pace/js")
                .Include("~/Scripts/pace.min.js");

            var coreScripts = new ScriptBundle("~/bundles/core/js")
                .Include("~/Assets/js/core/popper.min.js",
                         "~/Assets/js/core/bootstrap-material-design.min.js");

            var pluginScripts = new ScriptBundle("~/bundles/plugins/js")
                .Include("~/Assets/js/plugins/moment.min.js",
                         "~/Assets/js/plugins/bootstrap-datetimepicker.js",
                         "~/Assets/js/plugins/nouislider.min.js");

            var materialKitScripts = new ScriptBundle("~/bundles/material-kit/js")
                .Include("~/Assets/js/material-kit.js");


            // Adding Scripts

            bundles.Add(bootstrapScripts);
            bundles.Add(jQueryScripts);
            bundles.Add(jQueryValidationScripts);
            bundles.Add(paceScripts);
            bundles.Add(coreScripts);
            bundles.Add(pluginScripts);
            bundles.Add(materialKitScripts);
        }
    }
}