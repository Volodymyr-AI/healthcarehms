using StaffMS.WebAPI.Domain.UserRelated;

namespace StaffMS.WebAPI.Domain.Additional;

public class DepartmentPhoneNumberEntity
{
    public Guid Id { get; set; }
    public Guid DepartmentId { get; set; }
    public string PhoneNumber { get; set; }
    public DepartmentEntity Department { get; set; }
}