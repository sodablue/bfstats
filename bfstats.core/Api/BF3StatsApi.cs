using bfstats.core.Data;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace bfstats.core.Api
{
    public class BF3StatsApi
    {
        public async Task<IList<PlatformStat>> GetOnlinePlayers()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.bf3stats.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("global/onlinestats/");
                response.EnsureSuccessStatusCode();
                dynamic entry = await response.Content.ReadAsAsync<ExpandoObject>();

                var results = new List<PlatformStat>();

                results.Add(new PlatformStat
                {
                    TimeStamp = DateTimeOffset.Now,
                    Game = Game.BF3,
                    Platform = "PC",
                    Count = entry.pc
                });

                results.Add(new PlatformStat
                {
                    TimeStamp = DateTimeOffset.Now,
                    Game = Game.BF3,
                    Platform = "PS3",
                    Count = entry.ps3
                });

                results.Add(new PlatformStat
                {
                    TimeStamp = DateTimeOffset.Now,
                    Game = Game.BF3,
                    Platform = "XBOX360",
                    Count = (long)((IDictionary<string, object>)entry)["360"]
                });

                return results;
            }
        }
    }
}
