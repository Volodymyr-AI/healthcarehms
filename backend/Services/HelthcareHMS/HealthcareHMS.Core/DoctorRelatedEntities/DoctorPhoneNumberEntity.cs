namespace HealthcareHMS.Core;

public class DoctorPhoneNumberEntity
{
    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public string PhoneNumber { get; set; }
    public DoctorEntity Doctor { get; set; }
}