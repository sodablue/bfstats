using System.Data.Entity;
using Microsoft.WindowsAzure;

namespace bfstats.core.Data
{
    public class StatsContext : DbContext
    {
        public StatsContext() : base(CloudConfigurationManager.GetSetting("StatsContext"))
        {
            Database.SetInitializer<StatsContext>(new CreateDatabaseIfNotExists<StatsContext>());
        }

        public DbSet<Stats> Stats { get; set; }
    }
}
