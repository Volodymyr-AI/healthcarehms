namespace HealthcareHMS.Core.HospitalRelatedEntities;

public class HospitalFacilityEntity
{
    public Guid Id { get; set; }
    public Guid HospitalId { get; set; }
    public string Facility { get; set; }
    public HospitalEntity Hospital { get; set; }
}