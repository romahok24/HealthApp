using System.Linq.Expressions;

namespace HealthApp.Domain.Abstractions.Specification;

public abstract class Specification<T>
{
    public abstract Expression<Func<T, bool>> ToExpression();

    public Specification<T> And(Specification<T> specification)
    {
        return new AndSpecification<T>(this, specification);
    }
}
