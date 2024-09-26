using HealthApp.Application.Abstractions.Queries;
using HealthApp.Application.Abstractions.Repositories;
using HealthApp.Application.Extensions;
using HealthApp.Application.Patients.Get;
using HealthApp.Domain.Abstractions;

namespace HealthApp.Application.Patients.Search;

public sealed class SearchPatientQueryHandler : IQueryHandler<SearchPatientQuery, IReadOnlyList<PatientResponse>>
{
    private readonly IPatientRepository _patientRepository;

    public SearchPatientQueryHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result<IReadOnlyList<PatientResponse>>> Handle(
        SearchPatientQuery query,
        CancellationToken cancellationToken)
    {
        var specification = query
            .BirthDate
            .ToSpecification();

        var patients = await _patientRepository.SearchAsync(
            specification,
            cancellationToken);

        return patients
            .Select(x => new PatientResponse(
                new NameResponse(x.Name.Id, x.Name.Use, x.Name.Family, x.Name.Given),
                x.Gender,
                x.BirthDate,
                x.Active))
            .ToList();
    }
}