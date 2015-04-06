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
            var sut = new StatsApi(StatsSource.BF4);
            var result = sut.GetOnlinePlayers().Result;

            using (var context = new StatsContext())
            {
                context.Stats.Add(result);
                context.SaveChanges();
            }
        }

        [Test]
        public void Query_Database()
        {
            using (var context = new StatsContext())
            {
                var result = context.Stats.Count();

                Assert.That(result, Is.Not.EqualTo(0));
            }
        }

    }
}
