using Microsoft.AspNetCore.Identity;

namespace Cotrucking.Infrastructure.Entities.Security;
public class UserRoleDataModel : BaseEntity
{
    public virtual UserDataModel? User { get; set; }
    public virtual RoleDataModel? Role { get; set; }

    }