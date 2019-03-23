using System;
using System.Configuration;
using System.Web.Mvc;
using Clockwork.Web.ViewModels;

namespace Clockwork.Web.Controllers
{
    public class HomeController : Controller
    {
      private HomeViewModel GetViewModel()
      {
        var mvcName = typeof(Controller).Assembly.GetName();
        var isMono = Type.GetType("Mono.Runtime") != null;

        return new HomeViewModel()
        {
          Timezones = TimeZoneInfo.GetSystemTimeZones(),
          ApiUrl = ConfigurationManager.AppSettings["APIUrl"],
          Version = mvcName.Version.Major + "." + mvcName.Version.Minor,
          Runtime = isMono ? "Mono" : ".NET"
        };
      }

      public ActionResult Index()
      {
        var viewModel = GetViewModel();
        return View(viewModel);
      }
    }
}
