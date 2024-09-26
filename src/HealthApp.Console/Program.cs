using HealthApp.Console;
using HealthApp.Domain.Patients;
using System.Net.Http.Json;

var maleNames = new List<string>()
{
    "Роман",
    "Олег",
    "Артур",
    "Никита",
    "Ариан",
    "Евгений",
    "Максим",
    "Ростислав",
    "Александр",
    "Василий",
    "Иван",
    "Станислав",
    "Валерий",
    "Антон",
    "Анатолий",
};

var femaleNames = new List<string>()
{
    "Ольга",
    "Маргарита",
    "Елена",
    "Татьяна",
    "Милана",
    "Елизавета",
    "Анна",
    "Вероника",
    "Вера",
    "Василиса",
    "Полина",
    "Ксения",
    "Валерия",
    "Анастасия",
    "Виктория",
};

var maleFamily = new List<string>()
{
    "Иванов",
    "Петров",
    "Журович",
    "Солодкий",
    "Статкевич",
    "Долидович",
    "Криволевич",
    "Ступень",
    "Савастевеев",
    "Цариков",
    "Козлов",
    "Жаров",
    "Шубов",
    "Коноваленко",
    "Грицук",
    "Мышко",
    "Сташук",
};

var femaleFamily = new List<string>()
{
    "Иванова",
    "Петрова",
    "Журович",
    "Солодкая",
    "Статкевич",
    "Долидович",
    "Криволевич",
    "Ступень",
    "Савастевеева",
    "Царикова",
    "Козлова",
    "Жарова",
    "Шубова",
    "Коноваленко",
    "Грицук",
    "Мышко",
    "Сташук",
};

var maleSurnames = new List<string>()
{
    "Романович",
    "Олегович",
    "Артурович",
    "Никитич",
    "Арианович",
    "Евгеньевич",
    "Максимович",
    "Ростиславович",
    "Александрович",
    "Васильевич",
    "Иванович",
    "Станиславович",
    "Валерьевич",
    "Антонович",
    "Анатольевич",
};

var femaleSurnames = new List<string>()
{
    "Романовна",
    "Олеговна",
    "Артуровна",
    "Никитична",
    "Ариановна",
    "Евгеньевна",
    "Максимовна",
    "Ростиславовна",
    "Александровна",
    "Васильевна",
    "Ивановна",
    "Станиславовна",
    "Валерьевна",
    "Антоновна",
    "Анатольевна",
};

var males = Generator.GeneratePatient(maleNames, maleFamily, maleSurnames, Gender.Male, 50);
var females = Generator.GeneratePatient(femaleNames, femaleFamily, femaleSurnames, Gender.Female, 50);

using var client = new HttpClient();

foreach (var human in females.Concat(males))
{
    var response = await client.PostAsJsonAsync("http://localhost/patients", human);
    Console.WriteLine(response.StatusCode);
}