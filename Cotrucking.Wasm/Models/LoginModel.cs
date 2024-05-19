using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cotrucking.Wasm.Models;

public class LoginModel
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Email { get; set; }
    [PasswordPropertyText]
    public string Password { get; set; }

}