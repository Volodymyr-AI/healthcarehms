namespace HealthcareHMS.Core;

public class PractiseEntity
{
    public int Id { get; set; }
    public Guid DoctorId { get; set; }
    public string Practise { get; set; }
    
    public DoctorEntity Doctor { get; set; }
}