namespace HealthcareHMS.Core;

public class CertificationEntity
{
    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public string Certification { get; set; }
    
    public DoctorEntity Doctor { get; set; }
}