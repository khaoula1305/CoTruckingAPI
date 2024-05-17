using Microsoft.AspNetCore.Identity;

namespace Cotrucking.Domain.Entities;

public class UserDataModel : IdentityUser<Guid>
{
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? ContactInformation { get; set; }
    public Guid RoleId { get; set; }
    public virtual RoleDataModel Role { get; set; } = new();
    public virtual TransporterDataModel? Transporter { get; set; }
    public virtual CustomerDataModel? Customer { get; set; }
}