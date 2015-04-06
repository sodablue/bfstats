using System;
using System.Diagnostics;
using bfstats.core.Api;
using bfstats.core.Data;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure;

namespace bfstats.getbf4job
{
    class Program
    {
        static void Main(string[] args)
        {
            JobHost host = new JobHost();
            host.Call(typeof(GetBF4StatsJob).GetMethod("GetStatsFromBF4"));
        }
    }
}
