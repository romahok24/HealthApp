using HealthApp.Application.Abstractions.Specification;
using HealthApp.Domain.Patients;
using HealthApp.Domain.Patients.Specification.BirthDate;

namespace HealthApp.Application.Extensions;

public static class SpecificationExtensions
{
    public static Specification<Patient> ToSpecification(this List<string> dateFilters)
    {
        Specification<Patient> specification = new AlwaysTrueSpecification<Patient>();

        if (dateFilters is { Count: 0 })
        {
            return specification;
        }

        foreach (var dateFilter in dateFilters) 
        {
            specification = specification.And(BirthDateSpecificationFactory.GetSpecification(dateFilter));
        }

        return specification;
    }
}