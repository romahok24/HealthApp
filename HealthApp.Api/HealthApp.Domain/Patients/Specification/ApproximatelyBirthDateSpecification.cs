using HealthApp.Domain.Abstractions.Specification;
using System.Linq.Expressions;

namespace HealthApp.Domain.Patients.Specification;

public class ApproximatelyBirthDateSpecification : Specification<Patient>
{
    private readonly DateTime _birthDate;

    public ApproximatelyBirthDateSpecification(DateTime birthDate)
    {
        _birthDate = birthDate;
    }

    public override Expression<Func<Patient, bool>> ToExpression()
    {
        var range = new TimeSpan(10, 0, 0, 0);

        return patient => patient.BirthDate >= _birthDate - range && 
                          patient.BirthDate <= _birthDate + range;
    }
}