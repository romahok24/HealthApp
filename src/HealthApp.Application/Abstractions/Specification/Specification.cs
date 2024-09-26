using MongoDB.Driver;

namespace HealthApp.Application.Abstractions.Specification;

public abstract class Specification<T>
{
    protected FilterDefinitionBuilder<T> FilterBuilder { get; } = Builders<T>.Filter;

    public abstract FilterDefinition<T> ToFilterDefinition();

    public Specification<T> And(Specification<T> specification)
        => new AndSpecification<T>(this, specification);
}