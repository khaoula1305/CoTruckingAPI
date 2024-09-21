using System.ComponentModel.DataAnnotations;

namespace Cotrucking.Infrastructure.Entities
{
    public class RefreshTokenDataModel
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime DateExpire { get; set; }
        public DateTime DateAdded { get; set; }
        public Guid UserId { get; set; }
        public virtual UserDataModel User { get; set; }

    }
}
