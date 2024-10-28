namespace StaffMS.Core.HospitalRelatedEntities;

public class DepartmentServiceEntity
{
    public Guid Id { get; set; }
    public Guid HospitalId { get; set; }
    public string Service { get; set; }
    public DepartmentEntity Department { get; set; }
}