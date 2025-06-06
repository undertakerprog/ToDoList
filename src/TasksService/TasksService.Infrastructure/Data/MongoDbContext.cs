using MongoDB.Driver;
using TasksService.Domain.Entities;

namespace TasksService.Infrastructure.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<ToDoItem> ToDoItems => _database.GetCollection<ToDoItem>("ToDoItems");
}