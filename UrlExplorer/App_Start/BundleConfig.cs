using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace UrlExplorer.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.min.css",
                        "~/Content/jquery.fancybox.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.0.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                        "~/Scripts/popper.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/fancybox").Include(
                        "~/Scripts/jquery.fancybox.min.js"));
        }
    }
}