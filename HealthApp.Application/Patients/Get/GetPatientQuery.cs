using HealthApp.Application.Abstractions.Queries;
using HealthApp.Application.Patients.Dtos;

namespace HealthApp.Application.Patients.Get;

public sealed record GetPatientQuery : IQuery<List<PatientDto>>;
