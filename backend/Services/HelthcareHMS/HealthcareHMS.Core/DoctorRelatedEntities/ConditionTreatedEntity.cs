namespace HealthcareHMS.Core;

public class ConditionTreatedEntity
{
    public int Id { get; set; }
    public Guid DoctorId { get; set; }
    public string Condition { get; set; }
    
    public DoctorEntity Doctor { get; set; }
}