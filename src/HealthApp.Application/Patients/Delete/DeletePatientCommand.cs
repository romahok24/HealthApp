using HealthApp.Application.Abstractions.Commands;

namespace HealthApp.Application.Patients.Delete;

public sealed record DeletePatientCommand(Guid Id) : ICommand;