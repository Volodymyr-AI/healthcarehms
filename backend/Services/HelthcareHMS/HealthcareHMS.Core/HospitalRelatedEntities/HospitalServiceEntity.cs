namespace HealthcareHMS.Core.HospitalRelatedEntities;

public class HospitalServiceEntity
{
    public int Id { get; set; }
    public Guid HospitalId { get; set; }
    public string Service { get; set; }
    public HospitalEntity Hospital { get; set; }
}