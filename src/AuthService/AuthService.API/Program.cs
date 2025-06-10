using AuthService.Application.UseCases;
using AuthService.Domain.Interfaces;
using AuthService.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using AuthService.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true); //change to appsetting.json

builder.Services.AddControllers();
builder.Services.AddScoped<RegisterUseCase>();
builder.Services.AddScoped<LoginUseCase>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AuthDb")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthService", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthService v1"));
}

app.UseAuthorization();
app.MapControllers();

app.Run();