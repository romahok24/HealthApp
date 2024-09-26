using MongoDB.Driver;

namespace HealthApp.Application.Abstractions.Specification;

public class AlwaysTrueSpecification<T> : Specification<T>
{
    public override FilterDefinition<T> ToFilterDefinition()
        => FilterBuilder.Empty;
}
