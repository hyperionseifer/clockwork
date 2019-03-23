using System;
using System.Linq;
using System.Threading.Tasks;
using Clockwork.API.Data;
using Microsoft.AspNetCore.Mvc;
using Clockwork.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Clockwork.API.Controllers
{
    public class CurrentTimeController : Controller
    {
      private readonly ClockworkContext _context;

      public CurrentTimeController(ClockworkContext context)
      {
        _context = context;
      }

      // GET api/currenttime
      [Route("api/[controller]")]
      [HttpGet]
      public IActionResult GetTime([FromQuery] string timezoneId)
      {
        var timezone = TimeZoneInfo.FindSystemTimeZoneById(timezoneId);
        if (timezone == null)
          timezone = TimeZoneInfo.Utc;

        var utcTime = DateTime.UtcNow;
        var timezoneTime = TimeZoneInfo.ConvertTime(utcTime, TimeZoneInfo.Utc, timezone);
        var remoteIp = HttpContext.Connection.RemoteIpAddress.ToString();

        var currentTimeDetail = new CurrentTimeQuery
        {
          UTCTime = utcTime,
          ClientIp = remoteIp,
          Time = timezoneTime,
          TimezoneId = timezone.Id,
          Timezone = timezone.DisplayName
        };

        _context.CurrentTimeQueries.Add(currentTimeDetail);
        _context.SaveChanges();

        return Ok(currentTimeDetail);
    }

    [Route("api/[controller]/[action]")]
    [HttpGet]
    public async Task<IActionResult> QueryList([FromQuery] int? page)
    {
      var top = 20; // 20 records per page
      var skip = ((page ?? 1) - 1) * top; 
      var items = await _context.CurrentTimeQueries
                                .OrderByDescending(q => q.CurrentTimeQueryId)
                                .Skip(skip)
                                .Take(top)
                                .ToListAsync();
      return Ok(items);
    }
  }
}
