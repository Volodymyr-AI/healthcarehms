using FluentValidation;

namespace StaffMS.Application.MediatR.GlobalAdmin.Department.Commands.Create;

public class CreateDepartmentValidation : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentValidation()
    {
        RuleFor(x 
            => x.DepartmentName)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters");
        RuleFor(x =>
            x.Email)
            .NotEmpty().WithMessage("Email is required")
            .MaximumLength(100).WithMessage("Email must not exceed 100 characters");
        RuleFor(x =>
                x.GAId)
            .NotEqual(Guid.Empty).WithMessage("User not authorised");
    }
}