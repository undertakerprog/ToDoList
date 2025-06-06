using MongoDB.Driver;
using TasksService.Domain.Entities;
using TasksService.Domain.Interfaces;
using TasksService.Infrastructure.Data;

namespace TasksService.Infrastructure.Repositories;

public class ToDoRepository(MongoDbContext context) : IToDoRepository
{
    private readonly IMongoCollection<ToDoItem> _todoItems = context.ToDoItems;

    public async Task<List<ToDoItem>> GetAllAsync(string userId)
    {
        return await _todoItems.Find(item => item.UserId == userId).ToListAsync();
    }

    public async Task<ToDoItem?> GetByIdAsync(string id, string userId)
    {
        return await _todoItems.Find(item => item.Id == id && item.UserId == userId).FirstOrDefaultAsync();
    }

    public async Task<ToDoItem> CreateAsync(ToDoItem item)
    {
        await _todoItems.InsertOneAsync(item);
        return item;
    }

    public async Task UpdateAsync(string id, ToDoItem item)
    {
        await _todoItems.ReplaceOneAsync(i => i.Id == id, item);
    }

    public async Task DeleteAsync(string id, string userId)
    {
        await _todoItems.DeleteOneAsync(i => i.Id == id && i.UserId == userId);
    }
}