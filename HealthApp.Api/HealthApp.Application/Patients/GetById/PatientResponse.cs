using HealthApp.Domain.Patients;

namespace HealthApp.Application.Patients.GetById;

public sealed record PatientResponse(
    NameResponse Name,
    Gender Gender,
    DateTime BirthDate,
    bool Active);