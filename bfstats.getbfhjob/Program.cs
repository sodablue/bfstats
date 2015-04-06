using bfstats.core.Api;
using bfstats.core.Data;
using Microsoft.Azure.WebJobs;

namespace bfstats.getbfhjob
{
    class Program
    {
        static void Main(string[] args)
        {
            JobHost host = new JobHost();
            host.Call(typeof(GetBFHStatsJob).GetMethod("GetStatsFromBFH"));
        }
    }
}
