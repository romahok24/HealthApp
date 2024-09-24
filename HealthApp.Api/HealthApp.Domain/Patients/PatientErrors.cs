using HealthApp.Domain.Abstractions;

namespace HealthApp.Domain.Patients;

public static class PatientErrors
{
    public static Error NotFound(Guid id) => Error.NotFound(
        $"{nameof(PatientErrors)}.{NotFound}",
        $"The patient with Id = '{id}' not found");
}
