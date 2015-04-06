using System;
using System.Diagnostics;
using bfstats.core.Api;
using bfstats.core.Data;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure;
using System.IO;

namespace bfstats.getbf4job
{
    public class GetBF4StatsJob
    {
        [NoAutomaticTrigger]
        public static void GetStatsFromBF4(TextWriter log)
        {
            var sut = new StatsApi(StatsSource.BF4);
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
