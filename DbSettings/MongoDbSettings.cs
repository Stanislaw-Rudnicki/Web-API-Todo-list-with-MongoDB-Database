namespace WebApplication7_MongoDB.Models;

public class MongoDbSettings : IMongoDbSettings
{
    public string UsersCollectionName { get; set; } = null!;
    public string TodosCollectionName { get; set; } = null!;
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}
