using WebApplication7_MongoDB.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace WebApplication7_MongoDB.Services;

public class TodosService : MongoDBService, ITodosService
{
    public TodosService(IOptions<MongoDbSettings> dbSettings) : base(dbSettings) { }

    public async Task<List<TodoDTO>> GetAsync()
    {
        return await _todos
            .Find(new BsonDocument()).Sort("{Created: -1}").ToListAsync();
    }

    public async Task<List<TodoDTO>> GetAsync(int pageSize, int page)
    {
        return await _todos
            .Find(new BsonDocument())
            .Sort("{Created: -1}")
            .Skip((page - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();
    }

    public async Task<TodoDTO> GetAsync(string id)
    {
        FilterDefinition<TodoDTO> filter = Builders<TodoDTO>.Filter.Eq("Id", id);
        
        var result = await _todos.FindAsync(filter);
        return result.FirstOrDefault();
    }

    public async Task<TodoDTO> CreateAsync(TodoDTO newTodo)
    {
        await _todos.InsertOneAsync(newTodo);
        return newTodo;
    }

    public async Task UpdateAsync(string id, TodoDTO updatedTodoDTO)
    {
        FilterDefinition<TodoDTO> filter = Builders<TodoDTO>.Filter.Eq("Id", id);
        
        await _todos.ReplaceOneAsync(filter, updatedTodoDTO);
        return;
    }

    public async Task MarkAsComlpetedAsync(string id)
    {
        FilterDefinition<TodoDTO> filter = Builders<TodoDTO>.Filter.Eq("Id", id);
        UpdateDefinition<TodoDTO> update = Builders<TodoDTO>.Update
            .Set(todo => todo.State, States.Completed)
            .Set(todo => todo.Closed, DateTime.Now);
        
        await _todos.UpdateOneAsync(filter, update);
        return;
    }
}
