namespace StaffMS.WebAPI.Domain.UserRelated;

public class StaffAdminEntity
{
    public Guid Id { get; set; }
    public string AdminName { get; set; }

    // Connection with the hospital
    public Guid DepartmentId { get; set; }
    public DepartmentEntity Department { get; set; }
}