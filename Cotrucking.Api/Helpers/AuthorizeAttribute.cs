using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using System.Text.Json;

namespace Cotrucking.Api.Helpers;
[System.AttributeUsage(System.AttributeTargets.Method, Inherited = true)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _previlege;
    private readonly string _page;

    public AuthorizeAttribute(string previlege, string page)
    {
        _previlege = previlege;
        _page = page;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {       
        //var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        //if (token == null)
        //{
        //    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        //    return;
        //}

       
        //if (!string.IsNullOrEmpty(token))
        //{

        //    var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");

        //    var expiry = identity.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.exp.ToString()));


        //    var privilegeString = identity.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Privileges.ToString()))?.Value ?? string.Empty;

        //    if (expiry == null)
        //    {
        //        context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        //        return;
        //    }

        //    HashSet<string>? privilegeHash = privilegeString?.Split(";").ToHashSet<string>();

        //    privilegeHash?.Add("ACCOUNT_MENU");
        //    privilegeHash?.Add("REJECT");
       

        //    var datetime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expiry.Value));
        //    if (datetime.UtcDateTime <= DateTime.UtcNow)
        //    {
        //        context.Result = new JsonResult(new { message = "Unauthorized : Token has expired" }) { StatusCode = StatusCodes.Status401Unauthorized };
        //        return;
        //    }

        //    context.HttpContext.User.AddIdentity(identity);

        //}

    }

    public static IEnumerable<Claim>? ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs?.Select(kvp => new Claim(kvp.Key, kvp.Value?.ToString() ?? string.Empty));
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
            default:
                break;
        }
        return Convert.FromBase64String(base64);
    }
}