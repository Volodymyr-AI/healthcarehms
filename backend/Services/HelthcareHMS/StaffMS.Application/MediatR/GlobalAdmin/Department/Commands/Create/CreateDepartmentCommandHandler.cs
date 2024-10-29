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
            GlobalAdminId = request.GAId,
            DepartmentName = request.DepartmentName,
            Email = request.Email,
            Address = request.Address
        };
        
        await _departmentRepository.AddAsync(newDepartment);
        await _departmentRepository.SaveChangesAsync(newDepartment, cancellationToken);
        
        return newDepartment;
    }
}