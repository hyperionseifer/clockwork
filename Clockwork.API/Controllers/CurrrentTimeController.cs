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
      public IActionResult Get()
      {
        var utcTime = DateTime.UtcNow;
        var serverTime = DateTime.Now;
        var remoteIp = HttpContext.Connection.RemoteIpAddress.ToString();

        var currentTimeDetail = new CurrentTimeQuery
        {
            UTCTime = utcTime,
            ClientIp = remoteIp,
            Time = serverTime
        };

        _context.CurrentTimeQueries.Add(currentTimeDetail);
        _context.SaveChanges();

        return Ok(currentTimeDetail);
      }

    [Route("api/[controller]/getall")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var items = await _context.CurrentTimeQueries.OrderByDescending(q => q.CurrentTimeQueryId).ToListAsync();
      return Ok(items);
    }
  }
}
