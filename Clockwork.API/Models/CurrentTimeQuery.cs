using System;

namespace Clockwork.API.Models
{
    public class CurrentTimeQuery
    {
        public int CurrentTimeQueryId { get; set; }
        public DateTime Time { get; set; }
        public string ClientIp { get; set; }
        public DateTime UTCTime { get; set; }
        public string TimezoneId { get; set; }
        public string Timezone { get; set; }
    }
}
