using HealthApp.Application.Abstractions.Commands;
using HealthApp.Application.Patients.Dtos;
using HealthApp.Domain.Patients;

namespace HealthApp.Application.Patients.Create;

public sealed record CreatePatientCommand(
    NameDto Name,
    Gender Gender,
    DateTime BirthDate, 
    bool Active)
    : ICommand<Guid>;
