using HealthApp.Application.Abstractions.Specification;
using MongoDB.Driver;

namespace HealthApp.Domain.Patients.Specification.BirthDate;

public class GreaterThanBirthDateSpecification : Specification<Patient>
{
    private readonly DateTime _birthDate;

    public GreaterThanBirthDateSpecification(DateTime birthDate)
    {
        _birthDate = birthDate;
    }

    public override FilterDefinition<Patient> ToFilterDefinition()
        => FilterBuilder.Gt(p => p.BirthDate, _birthDate);
}