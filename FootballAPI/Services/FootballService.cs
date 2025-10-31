using FootballApi.Models.DTO;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
namespace FootballApi.Services
{
    public class FootballService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiToken;
        private readonly IDistributedCache _cache;
        public FootballService(IConfiguration configuration, IDistributedCache cache)
        {
            _apiToken = configuration["FootballApiToken"];
            if (string.IsNullOrEmpty(_apiToken))
                throw new ArgumentException("FootballApiToken is missing in appsettings.json");

            _httpClient = new HttpClient { BaseAddress = new Uri("https://api.football-data.org/v4/") };
            _httpClient.DefaultRequestHeaders.Add("X-Auth-Token", _apiToken);
            _cache = cache;
        }

        private async Task<Team> GetTeamByNameAsync(string teamName)
        {
            try
            {
                const string cacheKey = "teams_list";
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                // Try to get from cache
                var cachedData = await _cache.GetStringAsync(cacheKey);
                TeamsResponse teamsResponse;

                if (!string.IsNullOrEmpty(cachedData))
                {
                    teamsResponse = JsonSerializer.Deserialize<TeamsResponse>(cachedData, options);
                }
                else
                {
                    var response = await _httpClient.GetAsync("teams?limit=200");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    teamsResponse = JsonSerializer.Deserialize<TeamsResponse>(content, options);

                    // Cache the response
                    var serialized = JsonSerializer.Serialize(teamsResponse);
                    await _cache.SetStringAsync(cacheKey, serialized, new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
                    });
                }

                return teamsResponse.Teams.FirstOrDefault(t => t.Name.Contains(teamName, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task<List<Match>> GetLast5MatchesAsync(int teamId)
        {
            try
            {
                var cacheKey = $"matches_last5_{teamId}";
                var cached = await _cache.GetStringAsync(cacheKey);
                if (cached != null)
                {
                    var matches = JsonSerializer.Deserialize<List<Match>>(cached);
                    return matches;
                }
                var dateTo = DateTime.UtcNow.ToString("yyyy-MM-dd");
                var dateFrom = DateTime.UtcNow.AddMonths(-3).ToString("yyyy-MM-dd");
                var response = await _httpClient.GetAsync($"teams/{teamId}/matches?status=FINISHED&dateFrom={dateFrom}&dateTo={dateTo}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var matchesResponse = JsonSerializer.Deserialize<MatchesResponse>(content, options);
                var result = matchesResponse.Matches.OrderByDescending(m => m.UtcDate).Take(5).ToList();

                var serialized = JsonSerializer.Serialize(result);
                await _cache.SetStringAsync(cacheKey, serialized, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
                });

                return result;
            }
            catch (Exception ex)
            {
                return new List<Match>();
            }
        }

        private async Task<Match?> GetNextFixtureAsync(int teamId)
        {
            string cacheKey = $"next_fixture_{teamId}";
            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            // trying cache
            var cachedJson = await _cache.GetStringAsync(cacheKey);
            if (cachedJson != null)
            {
                return JsonSerializer.Deserialize<Match>(cachedJson, jsonOptions);
            }
            try
            {
                var response = await _httpClient.GetAsync($"teams/{teamId}/matches?status=SCHEDULED&limit=1");
                if (!response.IsSuccessStatusCode)
                {
                    await _cache.SetStringAsync(
                        cacheKey,
                        "null", 
                        new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) });
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();
                var matchesResponse = JsonSerializer.Deserialize<MatchesResponse>(content, jsonOptions);
                var nextMatch = matchesResponse?.Matches?.FirstOrDefault();

                // caching in redis
                var serialized = nextMatch != null
                    ? JsonSerializer.Serialize(nextMatch, jsonOptions)
                    : "null"; 

                await _cache.SetStringAsync(
                    cacheKey,
                    serialized,
                    new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60) 
                    });

                return nextMatch;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task<List<Standing>> GetLeagueTableAsync(int teamId)
        {

            string cacheKey = $"league_table_{teamId}";
            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            // trying to get from cache
            var cachedJson = await _cache.GetStringAsync(cacheKey);
            if (cachedJson != null)
            {
                return JsonSerializer.Deserialize<List<Standing>>(cachedJson, jsonOptions)
                       ?? new List<Standing>();
            }
            try
            {
                var teamResp = await _httpClient.GetAsync($"teams/{teamId}");
                teamResp.EnsureSuccessStatusCode();
                var teamJson = await teamResp.Content.ReadAsStringAsync();
                var team = JsonSerializer.Deserialize<Team>(teamJson, jsonOptions);

                var comp = team?.RunningCompetitions?.FirstOrDefault();
                if (comp == null)
                {
                    return new List<Standing>();
                }

                var standingsResp = await _httpClient.GetAsync($"competitions/{comp.Id}/standings");
                if (!standingsResp.IsSuccessStatusCode)
                {
                    return new List<Standing>();
                }

                var standingsJson = await standingsResp.Content.ReadAsStringAsync();
                var standings = JsonSerializer.Deserialize<StandingsResponse>(standingsJson, jsonOptions);

                var result = standings?.Standings?.FirstOrDefault()?.Table ?? new List<Standing>();

                // caching in redis
                var serialized = JsonSerializer.Serialize(result, jsonOptions);
                await _cache.SetStringAsync(
                    cacheKey,
                    serialized,
                    new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
                    });

                return result;
            }
            catch (Exception ex)
            {
                return new List<Standing>();
            }
        }

        public async Task<TeamInfo> GetTeamInfoAsync(string teamName)
        {
            var team = await GetTeamByNameAsync(teamName);
            if (team == null)
            {
                Console.WriteLine($"Team not found: {teamName}");
                return null;
            }

            var last5 = await GetLast5MatchesAsync(team.Id);
            var next = await GetNextFixtureAsync(team.Id);
            var table = await GetLeagueTableAsync(team.Id);

            return new TeamInfo
            {
                Last5Matches = last5,
                NextFixture = next,
                LeagueTable = table
            };
        }
    }
}
