using HealthApp.Domain.Patients;

namespace HealthApp.Console;

internal class Generator
{
    public static List<Patient> GeneratePatient(
        List<string> names,
        List<string> secondNames,
        List<string> surnames,
        Gender gender,
        int count)
    {
        var active = false;
        var random = new Random();
        var patients = new List<Patient>();
        
        for (int i = 0; i < count; i++)
        {
            active = !active;

            var firstName = names[random.Next(names.Count)];
            var secondName = secondNames[random.Next(secondNames.Count)];
            var surname = surnames[random.Next(surnames.Count)];

            var year = random.Next(1950, 2024);
            var month = random.Next(1, 12);
            var day = random.Next(1, DateTime.DaysInMonth(year, month));

            var hour = random.Next(1, 24);
            var minute = random.Next(1, 60);      

            var patient = new Patient
            {
                Name = GenerateName(firstName, secondName, surname),
                Gender = gender,
                BirthDate = new DateTime(year, month, day, hour, minute, 0),
                Active = active,
            };

            patients.Add(patient);
        }

        return patients;
    }

    private static Name GenerateName(
        string name, 
        string secondName, 
        string surname) =>
            new()
            {
                Id = Guid.NewGuid(),
                Family = secondName,
                Given = new() { name, surname },
                Use = "official"
            };
}
