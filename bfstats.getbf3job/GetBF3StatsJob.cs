using bfstats.core.Api;
using bfstats.core.Data;
using Microsoft.Azure.WebJobs;
using System.IO;

namespace bfstats.getbf3job
{
    public class GetBF3StatsJob
    {
        [NoAutomaticTrigger]
        public static void GetStatsFromBF3(TextWriter log)
        {
            var sut = new BF3StatsApi();
            var result = sut.GetOnlinePlayers().Result;

            using (var context = new StatsContext())
            {
                context.PlatformStats.AddRange(result);
                context.SaveChanges();
            }
        }

    }
}
