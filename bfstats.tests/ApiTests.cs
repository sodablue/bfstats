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
            var sut = new BF4StatsApi();
            var result = sut.GetOnlinePlayers().Result;

            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result[0].Game, Is.EqualTo(Game.BF4));
        }

        [Test]
        public void Api_Calls_Bfh()
        {
            var sut = new BFHStatsApi();
            var result = sut.GetOnlinePlayers().Result;

            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result[0].Game, Is.EqualTo(Game.BFH));
        }

        [Test]
        public void Api_Calls_Bf3()
        {
            var sut = new BF3StatsApi();
            var result = sut.GetOnlinePlayers().Result;

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0].Game, Is.EqualTo(Game.BF3));
        }
    }
}
