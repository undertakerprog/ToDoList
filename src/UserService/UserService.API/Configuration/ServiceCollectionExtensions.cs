using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UserService.Application.Interfaces;
using UserService.Domain.Interfaces;
using UserService.Infrastructure.Data;
using UserService.Infrastructure.Repositories;

namespace UserService.API.Configuration;

public static class ServiceCollectionExtensions
{
    public static void AddUserServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UserDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("AuthDb")));

        services.AddScoped<IUserService, Application.UseCases.UserService>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserService API", Version = "v1" });
        });
    }
}