using Microsoft.AspNetCore.Identity;

namespace Cotrucking.Infrastructure.Entities
{
    public class RoleDataModel: IdentityRole<Guid>
    {
        public virtual ICollection<UserDataModel> Users { get; set; } = [];
    }
}