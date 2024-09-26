using HealthApp.Application.Abstractions.Queries;
using HealthApp.Application.Patients.Get;

namespace HealthApp.Application.Patients.Search;

public record SearchPatientQuery(List<string> BirthDate) : IQuery<IReadOnlyList<PatientResponse>>;
