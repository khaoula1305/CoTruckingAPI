using Microsoft.AspNetCore.Identity;

namespace Cotrucking.Domain.Entities
{
    public class RoleDataModel : IdentityRole<Guid>
    {
        public string? RoleName { get; set; }
        public virtual ICollection<UserDataModel> Users { get; set; } = [];
    }
}