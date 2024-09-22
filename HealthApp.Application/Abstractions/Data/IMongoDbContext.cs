using MongoDB.Driver;

namespace HealthApp.Application.Abstractions.Data;

public interface IMongoDbContext
{
    IMongoCollection<T> GetCollection<T>(string name);
}
