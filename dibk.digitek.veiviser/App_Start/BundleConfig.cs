using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace dibk.digitek.veiviser.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/bower_components/dibk-fb-webcommon/assets/js/scripts").Include(
                        "~/Content/bower_components/dibk-fb-webcommon/assets/js/main.min.js",
                        "~/Content/bower_components/vue/dist/vue.js",
                        "~/Content/bower_components/axios/dist/axios.min.js",
                        "~/Scripts/resourceMethods.js",
                        "~/Scripts/apiMethods.js"));

            bundles.Add(new StyleBundle("~/Content/bower_components/dibk-fb-webcommon/assets/css/styles").Include(
                        "~/Content/bower_components/dibk-fb-webcommon/assets/css/main.css",
                        "~/Content/site.css",
                        "~/Content/dibk-fb-webcommon-override.css",
                        "~/Content/wizard.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}