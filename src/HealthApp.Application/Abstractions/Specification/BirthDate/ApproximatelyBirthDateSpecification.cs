using HealthApp.Application.Abstractions.Specification;
using MongoDB.Driver;

namespace HealthApp.Domain.Patients.Specification.BirthDate;

public class ApproximatelyBirthDateSpecification : Specification<Patient>
{
    private readonly DateTime _birthDate;

    public ApproximatelyBirthDateSpecification(DateTime birthDate)
    {
        _birthDate = birthDate;
    }

    public override FilterDefinition<Patient> ToFilterDefinition()
    {
        var range = new TimeSpan(10, 0, 0, 0);

        var gte = FilterBuilder.Gte(patient => patient.BirthDate, _birthDate - range);
        var lte = FilterBuilder.Lte(patient => patient.BirthDate, _birthDate + range);

        return FilterBuilder.And(gte, lte);
    }
}