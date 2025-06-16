using Microsoft.AspNetCore.Http;

namespace UserService.API.Services;

public class IdentityService(IHttpContextAccessor httpContextAccessor)
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

    public (string UserId, string Role) GetUserIdentity()
    {
        var principal = _httpContextAccessor.HttpContext?.User;
        if (principal == null)
        {
            Console.WriteLine("HttpContext or User is null");
            throw new UnauthorizedAccessException("User context not available");
        }

        var userIdClaim = principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
        if (userIdClaim == null)
        {
            Console.WriteLine("NameIdentifier claim not found in token. Available claims:");
            foreach (var c in principal.Claims)
            {
                Console.WriteLine($"Claim: {c.Type} = {c.Value}");
            }
            throw new UnauthorizedAccessException("User ID not found in token");
        }

        var roleClaim = principal.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
        if (roleClaim == null)
        {
            Console.WriteLine("Role claim not found in token.");
            throw new UnauthorizedAccessException("User role not found in token");
        }

        var userId = userIdClaim.Value;
        var role = roleClaim.Value;
        Console.WriteLine($"Extracted userId: {userId}, role: {role}");
        return (userId, role);
    }
}