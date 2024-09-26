using HealthApp.Application.Abstractions.Data;
using MongoDB.Driver;
using static HealthApp.Infrastructure.Constants;

namespace HealthApp.Infrastructure.Data;

public class MongoDbContext : IMongoDbContext
{
    private IMongoClient _mongoClient;
    private IMongoDatabase _database;

    public MongoDbContext(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
        _database = _mongoClient.GetDatabase(Databases.HealthAppDb);
    }

    public IMongoCollection<T> GetCollection<T>(string name) 
        => _database.GetCollection<T>(name);
}
