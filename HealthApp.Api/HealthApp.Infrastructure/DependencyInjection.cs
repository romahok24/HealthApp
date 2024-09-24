using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace HealthApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string mongoConnectionString)
    {
        var mongoClientSettings = MongoClientSettings.FromConnectionString(mongoConnectionString);

        services.AddSingleton<IMongoClient>(new MongoClient(mongoClientSettings));

        return services;
    }
}
