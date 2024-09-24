using HealthApp.Application.Abstractions.Data;
using MongoDB.Driver;

namespace HealthApp.Infrastructure.Data;

public class MongoDbContext : IMongoDbContext
{
    private IMongoClient _mongoClient;
    private IMongoDatabase _database;

    public MongoDbContext(IMongoClient mongoClient)
    {
        // TODO: добавить бд
        _mongoClient = mongoClient;
        _database = _mongoClient.GetDatabase("");
    }

    public IMongoCollection<T> GetCollection<T>(string name) 
        => _database.GetCollection<T>(name);
}
