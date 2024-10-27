namespace HealthcareHMS.Core;

public class PractiseEntity
{
    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public string Practice { get; set; }
    
    public DoctorEntity Doctor { get; set; }
}