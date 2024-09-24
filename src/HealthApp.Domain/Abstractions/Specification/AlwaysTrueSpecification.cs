using System.Linq.Expressions;

namespace HealthApp.Domain.Abstractions.Specification;

public class AlwaysTrueSpecification<T> : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        return x => true;
    }
}
