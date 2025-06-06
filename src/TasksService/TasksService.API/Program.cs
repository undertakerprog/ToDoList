using Microsoft.OpenApi.Models;
using TasksService.Application.Interfaces;
using TasksService.Application.Services;
using TasksService.Domain.Interfaces;
using TasksService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TasksService API", Version = "v1" });
});

builder.Services.AddScoped<IToDoService, ToDoServiceImpl>();
builder.Services.AddScoped<IToDoRepository, ToDoRepository>();

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