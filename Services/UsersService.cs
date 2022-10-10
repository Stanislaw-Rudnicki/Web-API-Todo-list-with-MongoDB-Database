using WebApplication7_MongoDB.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace WebApplication7_MongoDB.Services;

public class UsersService : MongoDBService, IUsersService
{
    public UsersService(IOptions<MongoDbSettings> dbSettings) : base(dbSettings) { }

    public async Task<List<UserDTO>> GetAsync()
    {
        return await _users.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<UserDTO> CreateAsync(UserDTO newUser)
    {
        await _users.InsertOneAsync(newUser);
        return newUser;
    }
}

