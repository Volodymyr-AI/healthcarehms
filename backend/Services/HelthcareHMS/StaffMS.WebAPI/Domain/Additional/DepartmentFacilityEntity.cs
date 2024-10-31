using StaffMS.WebAPI.Domain.UserRelated;

namespace StaffMS.WebAPI.Domain.Additional;

public class DepartmentFacilityEntity
{
    public Guid Id { get; set; }
    public Guid DepartmentId { get; set; }
    public string Facility { get; set; }
    public DepartmentEntity Department { get; set; }
}