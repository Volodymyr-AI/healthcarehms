namespace HealthcareHMS.Core.HospitalRelatedEntities;

public class HospitalFacilityEntity
{
    public int Id { get; set; }
    public Guid HospitalId { get; set; }
    public string Facility { get; set; }
    public HospitalEntity Hospital { get; set; }
}