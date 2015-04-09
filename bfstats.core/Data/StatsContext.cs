using System.Data.Entity;
using System.Data.Entity.SqlServer;
using Microsoft.WindowsAzure;

namespace bfstats.core.Data
{
    [DbConfigurationType(typeof(StatsConfiguration))]
    public class StatsContext : DbContext
    {
        public StatsContext() : base(CloudConfigurationManager.GetSetting("StatsContext"))
        {
            Database.SetInitializer<StatsContext>(new CreateDatabaseIfNotExists<StatsContext>());
        }

        public DbSet<PlatformStat> PlatformStats { get; set; }
    }

    public class StatsConfiguration : DbConfiguration
    {
        public StatsConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}
