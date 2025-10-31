namespace FootballApi.Models.DTO
{
    public class TeamInfo
    {
        public List<Match> Last5Matches { get; set; }
        public Match NextFixture { get; set; }
        public List<Standing> LeagueTable { get; set; }
    }

}
