﻿
using Microsoft.AspNetCore.Identity;

namespace Cotrucking.Infrastructure.Entities;

public class UserDataModel : IdentityUser<Guid>
{
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? PersonalPhoneNumber { get; set; }
    public Guid RoleId { get; set; }
    public virtual RoleDataModel Role { get; set; } = new();
    public virtual DriverDataModel? Driver { get; set; }
    public virtual CustomerDataModel? Customer { get; set; }
    public virtual EmployeeDataModel? Employee { get; set; }
}