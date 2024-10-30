using MediatR;
using StaffMS.Core;

namespace StaffMS.Application.MediatR.GlobalAdmin.Department.Commands.Create;

public class CreateDepartmentCommand : IRequest<DepartmentEntity>
{
    public string DepartmentName { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public Guid GAId { get; set; }
}