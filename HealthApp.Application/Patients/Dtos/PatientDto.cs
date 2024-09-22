using HealthApp.Domain.Enums;

namespace HealthApp.Application.Patients.Dtos;

public record PatientDto(
    NameDto Name, 
    Gender Gender, 
    DateTime BirthDate, 
    bool Active);
