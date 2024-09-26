using HealthApp.Application.Abstractions.Specification;
using MongoDB.Driver;

namespace HealthApp.Domain.Patients.Specification.BirthDate;

public class EqualsBirthDateSpecification : Specification<Patient>
{
    private readonly DateTime _birthDate;

    public EqualsBirthDateSpecification(DateTime birthDate)
    {
        _birthDate = birthDate;
    }

    public override FilterDefinition<Patient> ToFilterDefinition()
        => FilterBuilder.Eq(p =>  p.BirthDate, _birthDate);
}
