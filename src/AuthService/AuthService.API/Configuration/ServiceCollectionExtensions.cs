using AuthService.Application.Interfaces;
using AuthService.Domain.Interfaces;
using AuthService.Infrastructure.Data;
using AuthService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace AuthService.API.Configuration;

public static class ServiceCollectionExtensions
{
    public static void AddAuthServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AuthDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("AuthDb")));
        
        services.AddScoped<IAuthService, Application.Service.AuthService>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthService", Version = "v1" });
        });
    }
}