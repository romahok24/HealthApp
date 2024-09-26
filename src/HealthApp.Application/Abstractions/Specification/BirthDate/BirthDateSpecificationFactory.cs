using HealthApp.Application.Abstractions.Specification;

namespace HealthApp.Domain.Patients.Specification.BirthDate;

public class BirthDateSpecificationFactory
{
    public static Specification<Patient> GetSpecification(string dateFilter)
    {
        var date = DateTime.Parse(dateFilter[2..]);
        var prefix = dateFilter[..2];

        return prefix switch
        {
            "eq" => new EqualsBirthDateSpecification(date),
            "ne" => new NotEqualsBirthDateSpecification(date),
            "lt" or "eb" => new LessThanBirthDateSpecification(date),
            "gt" or "sa" => new GreaterThanBirthDateSpecification(date),
            "le" => new LessOrEqualsBirthDateSpecification(date),
            "ge" => new GreaterOrEqualsBirthDateSpecification(date),
            "ap" => new ApproximatelyBirthDateSpecification(date),
            _ => default!,
        };
    }
}
