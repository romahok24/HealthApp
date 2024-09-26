using MongoDB.Driver;

namespace HealthApp.Application.Abstractions.Specification;

public class AndSpecification<T> : Specification<T>
{
    private readonly Specification<T> _left;
    private readonly Specification<T> _right;

    public AndSpecification(
        Specification<T> left,
        Specification<T> right)
    {
        _right = right;
        _left = left;
    }

    public override FilterDefinition<T> ToFilterDefinition()
    {
        return FilterBuilder.And(_left.ToFilterDefinition(), _right.ToFilterDefinition());
    }
}
