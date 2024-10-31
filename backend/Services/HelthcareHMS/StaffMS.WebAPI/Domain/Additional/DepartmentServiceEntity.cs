using StaffMS.WebAPI.Domain.UserRelated;

namespace StaffMS.WebAPI.Domain.Additional;

public class DepartmentServiceEntity
{
    public Guid Id { get; set; }
    public Guid DepartmentId { get; set; }
    public string Service { get; set; }
    public DepartmentEntity Department { get; set; }
}