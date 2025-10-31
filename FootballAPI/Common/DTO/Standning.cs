using System.Text.Json.Serialization;
namespace FootballApi.Models.DTO
{
    public class Standing
    {
        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("team")]
        public Team Team { get; set; }

        [JsonPropertyName("playedGames")]
        public int PlayedGames { get; set; }

        [JsonPropertyName("won")]
        public int Won { get; set; }

        [JsonPropertyName("draw")]
        public int Draw { get; set; }

        [JsonPropertyName("lost")]
        public int Lost { get; set; }

        [JsonPropertyName("points")]
        public int Points { get; set; }
    }

    public class StandingsResponse
    {
        [JsonPropertyName("standings")]
        public List<StandingGroup> Standings { get; set; }
    }

    public class StandingGroup
    {
        [JsonPropertyName("table")]
        public List<Standing> Table { get; set; }
    }
}
