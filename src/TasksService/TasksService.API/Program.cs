using Microsoft.OpenApi.Models;
using TasksService.API.Configuration;
using TasksService.Application.Interfaces;
using TasksService.Application.UseCases;
using TasksService.Application.UseCases.CommandHandlers;
using TasksService.Application.UseCases.Interfaces;
using TasksService.Application.UseCases.QueryHandlers;
using TasksService.Domain.Interfaces;
using TasksService.Infrastructure.Data;
using TasksService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TasksService API", Version = "v1" });
});

builder.Services.AddTaskServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TasksService API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();