namespace HealthcareHMS.Core;

public class LicenseEntity
{
    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public string License { get; set; }
    
    public DoctorEntity Doctor { get; set; }    
}