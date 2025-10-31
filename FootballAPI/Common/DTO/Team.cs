using System.Text.Json.Serialization;
namespace FootballApi.Models.DTO
{
    public class Team
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("runningCompetitions")]
        public List<Competition> RunningCompetitions { get; set; }
    }

    public class Competition
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }
    }

    public class TeamsResponse
    {
        [JsonPropertyName("teams")]
        public List<Team> Teams { get; set; }
    }
}
