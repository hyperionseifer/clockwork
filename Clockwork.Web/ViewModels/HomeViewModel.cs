using System;
using System.Collections.Generic;

namespace Clockwork.Web.ViewModels
{
  public class HomeViewModel
  {
    public ICollection<TimeZoneInfo> Timezones { get; set; }
    public string ApiUrl { get; set; }
    public string Version { get; set; }
    public string Runtime { get; set; }
  }
}