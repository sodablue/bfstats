using bfstats.core.Api;
using bfstats.core.Data;
using NUnit.Framework;

namespace bfstats.tests
{
    [TestFixture]
    public class ApiTests
    {
        [Test]
        public void Api_Calls_Bf4()
        {
            var sut = new StatsApi(StatsSource.BF4);
            var result = sut.GetOnlinePlayers().Result;

            Assert.That(result.PC_Count, Is.GreaterThan(0));
            Assert.That(result.Source, Is.EqualTo(StatsSource.BF4));
        }

        [Test]
        public void Api_Calls_Bfh()
        {
            var sut = new StatsApi(StatsSource.BFH);
            var result = sut.GetOnlinePlayers().Result;

            Assert.That(result.PC_Count, Is.GreaterThan(0));
            Assert.That(result.Source, Is.EqualTo(StatsSource.BFH));
        }

    }
}
