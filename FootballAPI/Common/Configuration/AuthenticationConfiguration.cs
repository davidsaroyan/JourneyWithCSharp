namespace FootballApi.Common.Configuration
{
    public class AuthenticationConfiguration
    {
        public string Secret { get; set; }
        public int? AccessTokenLifeTimeMinutes { get; set; }
        public int? RefreshTokenLifeTimeMinutes { get; set; }
    }
}
