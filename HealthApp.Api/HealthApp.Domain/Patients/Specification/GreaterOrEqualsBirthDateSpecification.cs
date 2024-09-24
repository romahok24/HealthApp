using HealthApp.Domain.Abstractions.Specification;
using System.Linq.Expressions;

namespace HealthApp.Domain.Patients.Specification;

public class GreaterOrEqualsBirthDateSpecification : Specification<Patient>
{
    private readonly DateTime _birthDate;

    public GreaterOrEqualsBirthDateSpecification(DateTime birthDate)
    {
        _birthDate = birthDate;
    }

    public override Expression<Func<Patient, bool>> ToExpression()
    {
        return patient => patient.BirthDate >= _birthDate;
    }
}