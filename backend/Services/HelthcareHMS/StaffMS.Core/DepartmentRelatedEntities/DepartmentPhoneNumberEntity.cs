namespace StaffMS.Core.HospitalRelatedEntities;

public class DepartmentPhoneNumberEntity
{
    public Guid Id { get; set; }
    public Guid HospitalId { get; set; }
    public string PhoneNumber { get; set; }
    public DepartmentEntity Department { get; set; }
}