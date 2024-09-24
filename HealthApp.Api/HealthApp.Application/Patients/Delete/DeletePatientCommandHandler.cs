using HealthApp.Application.Abstractions.Commands;
using HealthApp.Application.Abstractions.Repositories;
using HealthApp.Domain.Abstractions;
using HealthApp.Domain.Patients;

namespace HealthApp.Application.Patients.Delete;

internal sealed class DeletePatientCommandHandler : ICommandHandler<DeletePatientCommand>
{
    private readonly IPatientRepository _patientRepository;

    internal DeletePatientCommandHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result> Handle(
        DeletePatientCommand command,
        CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByIdAsync(
            command.Id, 
            cancellationToken);

        if (patient is null)
        {
            return Result.Failure(PatientErrors.NotFound(command.Id));
        }

        await _patientRepository.DeleteAsync(command.Id, cancellationToken);

        return Result.Success();
    }
}