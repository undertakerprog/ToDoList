using FluentValidation;
using TasksService.Application.DTOs;
using TasksService.Application.Interfaces;
using TasksService.Application.UseCases;
using TasksService.Application.UseCases.CommandHandlers;
using TasksService.Application.UseCases.Interfaces;
using TasksService.Application.UseCases.QueryHandlers;
using TasksService.Application.Validators;
using TasksService.Domain.Interfaces;
using TasksService.Infrastructure.Data;
using TasksService.Infrastructure.Repositories;

namespace TasksService.API.Configuration;

public static class ServiceCollectionExtensions
{
    public static void AddTaskServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IToDoService, ToDoService>();
        services.AddScoped<ICommandHandler, CommandDispatcher>();
        services.AddScoped<IQueryHandler, QueryDispatcher>();
        services.AddScoped<CreateToDoItemCommandHandler>();
        services.AddScoped<UpdateToDoItemCommandHandler>();
        services.AddScoped<DeleteToDoItemCommandHandler>();
        services.AddScoped<MarkAsCompletedCommandHandler>();
        services.AddScoped<MarkAsIncompleteCommandHandler>();
        services.AddScoped<ArchiveTaskCommandHandler>();
        services.AddScoped<RestoreTaskCommandHandler>();
        services.AddScoped<SetPriorityCommandHandler>();
        services.AddScoped<AddTagCommandHandler>();
        services.AddScoped<RemoveTagCommandHandler>();
        services.AddScoped<SetDeadlineCommandHandler>();
        services.AddScoped<GetAllToDoItemsQueryHandler>();
        services.AddScoped<GetToDoItemByIdQueryHandler>();
        services.AddScoped<IToDoRepository, ToDoRepository>();
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
        services.AddSingleton<MongoDbContext>(_ =>
        {
            var settings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
            return new MongoDbContext(settings!.ConnectionString, settings.DatabaseName);
        });
        
        services.AddScoped<IValidator<ToDoItemCreateDto>, ToDoItemCreateDtoValidator>();
        services.AddScoped<IValidator<TaskCharacteristicsDto>, TaskCharacteristicsDtoValidator>();
    }
}