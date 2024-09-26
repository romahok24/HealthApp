namespace HealthApp.Application.Patients.GetById;

public sealed record NameResponse(
    Guid Id,
    string? Use,
    string Family,
    List<string> Given);