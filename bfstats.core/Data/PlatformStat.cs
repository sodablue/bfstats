using System;

namespace bfstats.core.Data
{
    public class PlatformStat
    {
        public int Id { get; set; }

        public DateTimeOffset TimeStamp { get; set; }
        public string Game { get; set; }
        public string Platform { get; set; }

        public long Count { get; set; }
    }
}
