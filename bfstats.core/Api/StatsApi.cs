using bfstats.core.Data;
using System;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace bfstats.core.Api
{
    public class StatsApi
    {
        private readonly string _baseUrl;
        private readonly StatsSource _source;

        public StatsApi(StatsSource source)
        {
            _source = source;
            switch (source)
            {
                case StatsSource.BF4:
                    _baseUrl = "http://api.bf4stats.com/";
                    break;
                case StatsSource.BFH:
                    _baseUrl = "http://api.bfhstats.com/";
                    break;
            }
        }

        public async Task<Stats> GetOnlinePlayers()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("api/onlinePlayers");
                response.EnsureSuccessStatusCode();
                dynamic entry = await response.Content.ReadAsAsync<ExpandoObject>();

                var stats = new Stats
                {
                    Source = _source,
                    TimeStamp = DateTimeOffset.Now,
                    PC_Count = entry.pc.count,
                    PS3_Count = entry.ps3.count,
                    PS4_Count = entry.ps4.count,
                    XBox_Count = entry.xbox.count,
                    XOne_Count = entry.xone.count
                };

                return stats;
            }
        }
    }
}
