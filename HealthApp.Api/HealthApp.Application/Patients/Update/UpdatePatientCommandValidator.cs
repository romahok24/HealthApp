using FluentValidation;

namespace HealthApp.Application.Patients.Update;

public class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
{
    public UpdatePatientCommandValidator()
    {
        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.Name.Family).NotNull().NotEmpty();
        RuleFor(x => x.BirthDate).NotNull().NotEmpty();
        RuleFor(x => x.Gender).IsInEnum();
    }
}