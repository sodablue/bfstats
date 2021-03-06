﻿using bfstats.core.Api;
using bfstats.core.Data;
using Microsoft.Azure.WebJobs;
using System.IO;

namespace bfstats.getbf4job
{
    public class GetBF4StatsJob
    {
        [NoAutomaticTrigger]
        public static void GetStatsFromBF4(TextWriter log)
        {
            var sut = new BF4StatsApi();
            var result = sut.GetOnlinePlayers().Result;

            using (var context = new StatsContext())
            {
                context.PlatformStats.AddRange(result);
                context.SaveChanges();
            }
        }

    }
}
