using System.IO;
using bfstats.core.Api;
using bfstats.core.Data;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure;

namespace bfstats.getbfhjob
{
    public class GetBFHStatsJob
    {
        [NoAutomaticTrigger]
        public static void GetStatsFromBFH(TextWriter log)
        {
            var sut = new StatsApi(StatsSource.BFH);
            var result = sut.GetOnlinePlayers().Result;

            log.WriteLine("cs: {0}", CloudConfigurationManager.GetSetting("StatsContext"));

            using (var context = new StatsContext())
            {
                context.Stats.Add(result);
                context.SaveChanges();
            }
        }

    }
}
