namespace FootballApi.Common.Entities
{
    public class RefreshToken
    {
        public string RefreshTokenId { get; set; } = Guid.NewGuid().ToString("N");
        public int UserId { get; set; }
    }
}
