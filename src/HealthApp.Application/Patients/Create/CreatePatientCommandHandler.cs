using HealthApp.Application.Abstractions.Commands;
using HealthApp.Application.Abstractions.Repositories;
using HealthApp.Domain.Abstractions;
using HealthApp.Domain.Patients;

namespace HealthApp.Application.Patients.Create;

public sealed class CreatePatientCommandHandler : ICommandHandler<CreatePatientCommand, Guid>
{
    private readonly IPatientRepository _patientRepository;

    public CreatePatientCommandHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result<Guid>> Handle(
        CreatePatientCommand command,
        CancellationToken cancellationToken)
    {
        var name = new Name
        {
            Use = command.Name.Use,
            Family = command.Name.Family,
            Given = command.Name.Given,
        };

        var patient = new Patient
        {
            Name = name,
            Gender = command.Gender,
            BirthDate = command.BirthDate,
            Active = command.Active
        };

        await _patientRepository.CreateAsync(
            patient, 
            cancellationToken);

        return patient.Name.Id;
    }
}
