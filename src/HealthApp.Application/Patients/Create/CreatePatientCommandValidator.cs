using FluentValidation;

namespace HealthApp.Application.Patients.Create;

public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientCommandValidator()
    {
        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.Name.Family).NotNull().NotEmpty();
        RuleFor(x => x.BirthDate).NotNull().NotEmpty();
        RuleFor(x => x.Gender).IsInEnum();
    }
}