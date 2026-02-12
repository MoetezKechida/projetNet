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
        
        var settings = MongoClientSettings.FromConnectionString(connectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        settings.UseTls = true;
        settings.AllowInsecureTls = true;
        settings.SslSettings = new SslSettings
        {
            CheckCertificateRevocation = false,
            EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 | System.Security.Authentication.SslProtocols.Tls13
        };
        settings.DirectConnection = false;
        settings.ServerSelectionTimeout = TimeSpan.FromSeconds(30);
        
        var client = new MongoClient(settings);
        _database = client.GetDatabase("VehiclePlatform");
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }
}