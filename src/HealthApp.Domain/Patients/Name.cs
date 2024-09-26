namespace HealthApp.Domain.Patients;

public class Name
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Use { get; set; }
    public string Family { get; set; } = string.Empty;
    public List<string> Given { get; set; } = new();
}