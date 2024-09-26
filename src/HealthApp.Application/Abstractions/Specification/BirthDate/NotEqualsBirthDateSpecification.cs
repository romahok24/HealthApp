using HealthApp.Application.Abstractions.Specification;
using MongoDB.Driver;

namespace HealthApp.Domain.Patients.Specification.BirthDate;

public class NotEqualsBirthDateSpecification : Specification<Patient>
{
    private readonly DateTime _birthDate;

    public NotEqualsBirthDateSpecification(DateTime birthDate)
    {
        _birthDate = birthDate;
    }

    public override FilterDefinition<Patient> ToFilterDefinition()
        => FilterBuilder.Ne(p => p.BirthDate, _birthDate);
}