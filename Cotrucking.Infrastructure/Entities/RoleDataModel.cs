using Microsoft.AspNetCore.Identity;

namespace Cotrucking.Infrastructure.Entities
{
    public class RoleDataModel : BaseEntity
    {
        public string? RoleName { get; set; }
        public virtual ICollection<UserDataModel> Users { get; set; } = [];
    }
}