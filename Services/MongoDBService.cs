using WebApplication7_MongoDB.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace WebApplication7_MongoDB.Services;

public class MongoDBService
{
    protected readonly IMongoCollection<UserDTO> _users;
    protected readonly IMongoCollection<TodoDTO> _todos;

    public MongoDBService(IOptions<MongoDbSettings> dbSettings)
    {
        var client = new MongoClient(Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING"));
        var db = client.GetDatabase(dbSettings.Value.DatabaseName);
        _users = db.GetCollection<UserDTO>(dbSettings.Value.UsersCollectionName);
        _todos = db.GetCollection<TodoDTO>(dbSettings.Value.TodosCollectionName);
    }
}

