using HealthApp.Application.Abstractions.Queries;

namespace HealthApp.Application.Patients.Get;

public sealed record GetPatientQuery(List<string> BirthDate) : IQuery<IReadOnlyList<PatientResponse>>;
