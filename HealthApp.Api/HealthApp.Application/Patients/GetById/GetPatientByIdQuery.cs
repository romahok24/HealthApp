using HealthApp.Application.Abstractions.Queries;
using HealthApp.Application.Patients.Get;

namespace HealthApp.Application.Patients.GetById;

public sealed record GetPatientByIdQuery(Guid Id) : IQuery<PatientResponse>;
