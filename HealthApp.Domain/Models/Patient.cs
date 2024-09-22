using HealthApp.Domain.Enums;

namespace HealthApp.Domain.Models;

public class Patient
{
    public Name Name { get; set; }
    public Gender Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Active { get; set; }
}
