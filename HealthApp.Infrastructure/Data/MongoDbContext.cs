using HealthApp.Application.Abstractions.Data;
using MongoDB.Driver;

namespace HealthApp.Infrastructure.Data;

public class MongoDbContext : IMongoDbContext
{
    private IMongoClient _mongoClient;
    private IMongoDatabase _database;

    public MongoDbContext(string connectionString)
    {
        // TODO: исправить эту ахинею(MongoUrl)
        _mongoClient = new MongoClient(connectionString);
        _database = _mongoClient.GetDatabase("");
    }

    public IMongoCollection<T> GetCollection<T>(string name) 
        => _database.GetCollection<T>(name);
}
