using System.ComponentModel.DataAnnotations;

namespace Cotrucking.Domain.Models
{
    public class RefreshTokenRequest
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string RefreshToken { get; set; }

    }
}
