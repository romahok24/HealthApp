using HealthApp.Application.Abstractions.Queries;
using HealthApp.Application.Abstractions.Repositories;
using HealthApp.Application.Common;
using HealthApp.Application.Patients.Dtos;

namespace HealthApp.Application.Patients.Get;

internal sealed class GetPatientQueryHandler : IQueryHandler<GetPatientQuery, List<PatientDto>>
{
    private readonly IPatientRepository _patientRepository;

    internal GetPatientQueryHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result<List<PatientDto>>> Handle(
        GetPatientQuery query, 
        CancellationToken cancellationToken)
    {
        var patients = await _patientRepository.GetAllAsync(cancellationToken);

        return patients.Select(x => new PatientDto(new NameDto(x.Name.Id, x.Name.Use, x.Name.Family, x.Name.Given), x.Gender, x.BirthDate, x.Active)).ToList();
    }
}
