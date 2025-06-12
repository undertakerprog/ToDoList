using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UserService.Application.UseCases.Queries.Handlers;
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
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllUsersHandler).Assembly));

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserService API", Version = "v1" });
        });
    }
}