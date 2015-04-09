using System.IO;
using bfstats.core.Api;
using bfstats.core.Data;
using Microsoft.Azure.WebJobs;

namespace bfstats.getbfhjob
{
    public class GetBFHStatsJob
    {
        [NoAutomaticTrigger]
        public static void GetStatsFromBFH(TextWriter log)
        {
            var sut = new BFHStatsApi();
            var result = sut.GetOnlinePlayers().Result;

            using (var context = new StatsContext())
            {
                context.PlatformStats.AddRange(result);
                context.SaveChanges();
            }
        }

    }
}
