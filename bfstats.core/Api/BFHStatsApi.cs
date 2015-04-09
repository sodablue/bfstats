using bfstats.core.Data;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace bfstats.core.Api
{
    public class BFHStatsApi
    {
        public async Task<IList<PlatformStat>> GetOnlinePlayers()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.bfhstats.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("api/onlinePlayers");
                response.EnsureSuccessStatusCode();
                dynamic entry = await response.Content.ReadAsAsync<ExpandoObject>();

                var results = new List<PlatformStat>();

                results.Add(new PlatformStat
                {
                    TimeStamp = DateTimeOffset.Now,
                    Game = Game.BFH,
                    Platform = entry.pc.label,
                    Count = entry.pc.count
                });

                results.Add(new PlatformStat
                {
                    TimeStamp = DateTimeOffset.Now,
                    Game = Game.BFH,
                    Platform = entry.ps3.label,
                    Count = entry.ps3.count
                });

                results.Add(new PlatformStat
                {
                    TimeStamp = DateTimeOffset.Now,
                    Game = Game.BFH,
                    Platform = entry.xbox.label,
                    Count = entry.xbox.count
                });

                results.Add(new PlatformStat
                {
                    TimeStamp = DateTimeOffset.Now,
                    Game = Game.BFH,
                    Platform = entry.ps4.label,
                    Count = entry.ps4.count
                });

                results.Add(new PlatformStat
                {
                    TimeStamp = DateTimeOffset.Now,
                    Game = Game.BFH,
                    Platform = entry.xone.label,
                    Count = entry.xone.count
                });

                return results;
            }
        }
    }
}
