using HealthApp.Application.Abstractions.Commands;
using HealthApp.Application.Abstractions.Repositories;
using HealthApp.Domain.Abstractions;
using HealthApp.Domain.Patients;

namespace HealthApp.Application.Patients.Update;

internal sealed class UpdatePatientCommandHandler : ICommandHandler<UpdatePatientCommand, Guid>
{
    private readonly IPatientRepository _patientRepository;

    internal UpdatePatientCommandHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result<Guid>> Handle(
        UpdatePatientCommand command,
        CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByIdAsync(
            command.Name.Id,
            cancellationToken);

        if (patient is null)
        {
            return Result.Failure<Guid>(PatientErrors.NotFound(command.Name.Id));
        }

        patient.Name.Use = command.Name.Use;
        patient.Name.Family = command.Name.Family;
        patient.Name.Given = command.Name.Given;
        patient.Gender = command.Gender;
        patient.BirthDate = command.BirthDate;
        patient.Active = command.Active;

        await _patientRepository.UpdateAsync(
            patient,
            cancellationToken);

        return patient.Name.Id;
    }
}