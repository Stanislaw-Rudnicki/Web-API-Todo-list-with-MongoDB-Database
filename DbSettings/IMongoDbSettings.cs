namespace WebApplication7_MongoDB.Models;

public interface IMongoDbSettings
{
    string UsersCollectionName { get; set; }
    string TodosCollectionName { get; set; }

    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}
