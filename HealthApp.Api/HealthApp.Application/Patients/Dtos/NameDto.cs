namespace HealthApp.Application.Patients.Dtos;

public record NameDto(
    Guid Id, 
    string? Use, 
    string Family, 
    List<string> Given);
