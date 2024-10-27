using FluentValidation;

namespace HealthcareHMS.Application.MediatR.GlobalAdmin.Hospital.Commands.Create;

public class CreateHospitalCommandValidator : AbstractValidator<CreateHospitalCommand>
{
    public CreateHospitalCommandValidator()
    {
        RuleFor(x 
            => x.HospitalName)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(x => 
            x.GlobalAdminId).NotEqual(Guid.Empty);
    }
}