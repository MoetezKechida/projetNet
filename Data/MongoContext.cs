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
        var connectionString = configuration.GetConnectionString("MongoConnection");
        
        // Configure MongoDB client settings with SSL
        var settings = MongoClientSettings.FromConnectionString(connectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        settings.ConnectTimeout = TimeSpan.FromSeconds(30);
        settings.ServerSelectionTimeout = TimeSpan.FromSeconds(30);
        
        var client = new MongoClient(settings);
        _database = client.GetDatabase("VehiclePlatform");
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }
}