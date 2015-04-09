using Microsoft.Azure.WebJobs;

namespace bfstats.getbf3job
{
    class Program
    {
        static void Main(string[] args)
        {
            JobHost host = new JobHost();
            host.Call(typeof(GetBF3StatsJob).GetMethod("GetStatsFromBF3"));
        }
    }
}
