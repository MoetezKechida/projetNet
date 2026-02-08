using MongoDB.Driver;

namespace projetNet.Data;

public interface IMongoContext
{
    IMongoCollection<T> GetCollection<T>(string name);
}

public class MongoContext : IMongoContext
{
    private readonly IMongoDatabase _database;

    public MongoContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoConnection"));
        _database = client.GetDatabase("VehiclePlatform");
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }
}