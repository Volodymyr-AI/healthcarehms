namespace HealthcareHMS.Core.HospitalRelatedEntities;

public class HospitalPhoneNumberEntity
{
    public Guid Id { get; set; }
    public Guid HospitalId { get; set; }
    public string PhoneNumber { get; set; }
    public HospitalEntity Hospital { get; set; }
}