﻿namespace Cotrucking.Domain.Models;

public class UserModel
{
    public Title Title { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? PersonalPhoneNumber { get; set; }
    public Guid RoleId { get; set; }
}


public class UserSearch
{
    public string? Name { get; set; }
    public Guid? CompanyId { get; set; }
}


public class UserResponse
{
    public Guid Id { get; set; }
    public Title Title { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? PersonalPhoneNumber { get; set; }
    public Guid RoleId { get; set; }
}

public class UserInput
{
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? PersonalPhoneNumber { get; set; }
    public Guid RoleId { get; set; }
}

public class UserExport
{
    public Guid Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? PersonalPhoneNumber { get; set; }
    public Guid RoleId { get; set; }
}