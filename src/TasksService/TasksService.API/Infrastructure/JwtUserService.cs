using System.Security.Claims;
using TasksService.Application.Interfaces;

namespace TasksService.API.Infrastructure;

public class JwtUserService(IHttpContextAccessor httpContextAccessor) : IJwtUserService
{
    public string GetUserId()
    {
        var user = httpContextAccessor.HttpContext?.User;
        return user?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new UnauthorizedAccessException("User ID not found in token");
    }
}