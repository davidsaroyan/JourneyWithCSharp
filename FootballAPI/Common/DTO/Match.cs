using System.Text.Json.Serialization;
namespace FootballApi.Models.DTO
{
    public class Match
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("utcDate")]
        public DateTime UtcDate { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("homeTeam")]
        public MatchTeam HomeTeam { get; set; } 

        [JsonPropertyName("awayTeam")]
        public MatchTeam AwayTeam { get; set; } 

        [JsonPropertyName("score")]
        public Score Score { get; set; }
    }

    public class MatchTeam 
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Score
    {
        [JsonPropertyName("fullTime")]
        public FullTime FullTime { get; set; }
    }

    public class FullTime
    {
        [JsonPropertyName("home")]
        public int? Home { get; set; }

        [JsonPropertyName("away")]
        public int? Away { get; set; }
    }

    public class MatchesResponse
    {
        [JsonPropertyName("matches")]
        public List<Match> Matches { get; set; }
    }
}
