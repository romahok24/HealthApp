using HealthApp.Application.Abstractions.Data;
using HealthApp.Application.Abstractions.Repositories;
using HealthApp.Infrastructure.Data;
using HealthApp.Infrastructure.Repositories;
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

        services.AddTransient<IMongoDbContext, MongoDbContext>();
        services.AddTransient<IPatientRepository, PatientRepository>();

        return services;
    }
}
