using bfstats.core.Api;
using bfstats.core.Data;
using NUnit.Framework;
using System.Linq;

namespace bfstats.tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void BF4_Stats_ToDatabase()
        {
            var sut = new BF4StatsApi();
            var result = sut.GetOnlinePlayers().Result;

            using (var context = new StatsContext())
            {
                context.PlatformStats.AddRange(result);
                context.SaveChanges();
            }
        }

        [Test]
        public void Query_Database()
        {
            using (var context = new StatsContext())
            {
                var result = context.PlatformStats.Count();

                Assert.That(result, Is.Not.EqualTo(0));
            }
        }

    }
}
