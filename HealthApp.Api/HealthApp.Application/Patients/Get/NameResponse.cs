namespace HealthApp.Application.Patients.Get;

public sealed record NameResponse(
    Guid Id,
    string? Use,
    string Family,
    List<string> Given);