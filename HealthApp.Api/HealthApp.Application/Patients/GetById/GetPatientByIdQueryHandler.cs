using HealthApp.Application.Abstractions.Queries;
using HealthApp.Application.Abstractions.Repositories;
using HealthApp.Domain.Abstractions;
using HealthApp.Domain.Patients;

namespace HealthApp.Application.Patients.GetById;

internal sealed class GetPatientByIdQueryHandler : IQueryHandler<GetPatientByIdQuery, PatientResponse>
{
    private readonly IPatientRepository _patientRepository;

    internal GetPatientByIdQueryHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result<PatientResponse>> Handle(
        GetPatientByIdQuery query,
        CancellationToken cancellationToken)
    {
        var patients = await _patientRepository.GetByIdAsync(
            query.Id, 
            cancellationToken);

        if (patients is null)
        {
            return Result.Failure<PatientResponse>(PatientErrors.NotFound(query.Id));
        }

        var nameResponse = new NameResponse(
            patients.Name.Id,
            patients.Name.Use,
            patients.Name.Family,
            patients.Name.Given);

        return new PatientResponse(
            nameResponse,
            patients.Gender,
            patients.BirthDate,
            patients.Active);
    }
}
