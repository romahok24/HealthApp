using HealthApp.Application.Abstractions.Queries;

namespace HealthApp.Application.Patients.Get;

public sealed record GetPatientQuery() : IQuery<IReadOnlyList<PatientResponse>>;
