namespace Cotrucking.Domain.Models
{
    public class TokenModel
    {
        public string Token { get; set; } = default!;
        public DateTime ExpiresAt { get; set; }
        public string RefreshToken { get; set; }
    }
}
