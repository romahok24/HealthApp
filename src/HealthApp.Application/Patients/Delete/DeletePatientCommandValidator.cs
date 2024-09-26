using FluentValidation;

namespace HealthApp.Application.Patients.Delete;

public class DeletePatientCommandValidator : AbstractValidator<DeletePatientCommand>
{
    public DeletePatientCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}