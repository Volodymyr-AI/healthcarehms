namespace StaffMS.Core.HospitalRelatedEntities;

public class DepartmentFacilityEntity
{
    public Guid Id { get; set; }
    public Guid HospitalId { get; set; }
    public string Facility { get; set; }
    public DepartmentEntity Department { get; set; }
}