using HealthApp.Domain.Abstractions.Specification;
using System.Linq.Expressions;

namespace HealthApp.Domain.Patients.Specification;

public class NotEqualsBirthDateSpecification : Specification<Patient>
{
    private readonly DateTime _birthDate;

    public NotEqualsBirthDateSpecification(DateTime birthDate)
    {
        _birthDate = birthDate;
    }

    public override Expression<Func<Patient, bool>> ToExpression()
    {
        return patient => patient.BirthDate != _birthDate;
    }
}