using HealthApp.Application.Abstractions.Specification;
using MongoDB.Driver;

namespace HealthApp.Domain.Patients.Specification.BirthDate;

public class LessOrEqualsBirthDateSpecification : Specification<Patient>
{
    private readonly DateTime _birthDate;

    public LessOrEqualsBirthDateSpecification(DateTime birthDate)
    {
        _birthDate = birthDate;
    }

    public override FilterDefinition<Patient> ToFilterDefinition()
        => FilterBuilder.Lte(p => p.BirthDate, _birthDate);
}