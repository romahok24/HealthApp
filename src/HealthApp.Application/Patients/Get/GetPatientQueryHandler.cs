using HealthApp.Application.Abstractions.Queries;
using HealthApp.Application.Abstractions.Repositories;
using HealthApp.Domain.Abstractions;
using MongoDB.Driver;

namespace HealthApp.Application.Patients.Get;

public sealed class GetPatientQueryHandler : IQueryHandler<GetPatientQuery, IReadOnlyList<PatientResponse>>
{
    private readonly IPatientRepository _patientRepository;

    public GetPatientQueryHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result<IReadOnlyList<PatientResponse>>> Handle(
        GetPatientQuery query, 
        CancellationToken cancellationToken)
    {
        var patients = await _patientRepository.GetAllAsync(cancellationToken);
        
        return patients
            .Select(x => new PatientResponse(
                new NameResponse(x.Name.Id, x.Name.Use, x.Name.Family, x.Name.Given),
                x.Gender, 
                x.BirthDate, 
                x.Active))
            .ToList();
    }
}