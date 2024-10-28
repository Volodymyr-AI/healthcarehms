using MediatR;
using StaffMS.Application.Utils.Interfaces.Repositories;
using StaffMS.Core;

namespace StaffMS.Application.MediatR.GlobalAdmin.Department.Commands.Create;

public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, DepartmentEntity>
{
    private readonly IDepartmentRepository _departmentRepository;

    public CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<DepartmentEntity> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var newDepartment = new DepartmentEntity
        {
            Id = Guid.NewGuid(),
            DepartmentName = request.DepartmentName,
            Email = request.Email,
        };
        
        await _departmentRepository.AddAsync(newDepartment);
        await _departmentRepository.SaveChangesAsync(newDepartment, cancellationToken);
        
        return newDepartment;
    }
}