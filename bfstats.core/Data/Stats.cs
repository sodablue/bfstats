using System;

namespace bfstats.core.Data
{
    public enum StatsSource
    {
        BF4,
        BFH
    }

    public class Stats
    {
        public int Id { get; set; }

        public DateTimeOffset TimeStamp { get; set; }
        public StatsSource Source { get; set; }

        public long PC_Count { get; set; }
        public long PS3_Count { get; set; }
        public long XBox_Count { get; set; }
        public long XOne_Count { get; set; }
        public long PS4_Count { get; set; }
    }
}
