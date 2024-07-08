using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace CollegeSystem.BL.Utilities;

public class UserUtility
{
    private IHttpContextAccessor HttpContextAccessor { get; set; }
    public UserUtility(IHttpContextAccessor httpContextAccessor)
    {
        HttpContextAccessor = httpContextAccessor;
    }


    public long GetUserId()
    {
        var userId = HttpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        return long.Parse(userId!);
    }

    public string? GetUserName()
    {
        return HttpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
    }
}