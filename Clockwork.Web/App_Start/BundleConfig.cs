using System.Web.Optimization;

namespace Clockwork.Web
{
  public class BundleConfig
  {
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/js/base").Include(
        "~/Scripts/jquery-{version}.js",   
        "~/Scripts/bootstrap.js",
        "~/Scripts/moment.js",
        "~/Scripts/knockout-{version}.js", 
        "~/Scripts/knockout.mapping.js",
        "~/Scripts/application/app.js",
        "~/Scripts/application/models/current.time.query.js",
        "~/Scripts/application/viewmodels/home.vm.js"));

      bundles.Add(new ScriptBundle("~/js/app.start").Include(
        "~/Scripts/application/app.start.js"));

      bundles.Add(new ScriptBundle("~/js/ie8below").Include(
        "~/Scripts/ie8-responsive-file-warning.js",
        "~/Scripts/html5shiv.js",
        "~/Scripts/respond.js"));
      
      bundles.Add(new ScriptBundle("~/js/emulation").Include(
        "~/Scripts/ie-emulation-modes-warning.js"));

      bundles.Add(new ScriptBundle("~/js/emulation").Include(
        "~/Scripts/ie-emulation-modes-warning.js"));

      bundles.Add(new StyleBundle("~/content/base").Include(
        "~/Content/bootstrap.css",
        "~/Content/ie10-viewport-bug-workaround.css",
        "~/Content/global.css"));
    }
  }
}