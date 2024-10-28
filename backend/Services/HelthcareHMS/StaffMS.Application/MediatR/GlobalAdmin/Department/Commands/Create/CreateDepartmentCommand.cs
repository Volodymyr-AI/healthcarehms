using MediatR;
using StaffMS.Core;

namespace StaffMS.Application.MediatR.GlobalAdmin.Department.Commands.Create;

public class CreateDepartmentCommand : IRequest<DepartmentEntity>
{
    public string DepartmentName { get; set; }
    public string Email { get; set; }
    public Guid GAId { get; set; }
}