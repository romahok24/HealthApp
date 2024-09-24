using HealthApp.Domain.Patients;

namespace HealthApp.Application.Patients.Get;

public sealed record PatientResponse(
    NameResponse Name,
    Gender Gender,
    DateTime BirthDate,
    bool Active);