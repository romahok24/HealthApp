using HealthApp.Web.Api.Extensions;
using System.Reflection;

namespace HealthApp.Web.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(option =>
        {
            option.EnableAnnotations();
        });
        services.AddHealthChecks();

        services.AddEndpoints(Assembly.GetExecutingAssembly());

        return services;
    }
}
