using HealthApp.Application.Abstractions.Specification;
using MongoDB.Driver;

namespace HealthApp.Domain.Patients.Specification.BirthDate;

public class GreaterOrEqualsBirthDateSpecification : Specification<Patient>
{
    private readonly DateTime _birthDate;

    public GreaterOrEqualsBirthDateSpecification(DateTime birthDate)
    {
        _birthDate = birthDate;
    }

    public override FilterDefinition<Patient> ToFilterDefinition()
        => FilterBuilder.Gte(p => p.BirthDate, _birthDate);
}