using HealthApp.Application.Abstractions.Specification;
using MongoDB.Driver;

namespace HealthApp.Domain.Patients.Specification.BirthDate;

public class LessThanBirthDateSpecification : Specification<Patient>
{
    private readonly DateTime _birthDate;

    public LessThanBirthDateSpecification(DateTime birthDate)
    {
        _birthDate = birthDate;
    }

    public override FilterDefinition<Patient> ToFilterDefinition()
        => FilterBuilder.Lt(p => p.BirthDate, _birthDate);
}
