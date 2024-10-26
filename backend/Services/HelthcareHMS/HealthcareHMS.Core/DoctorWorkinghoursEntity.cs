namespace HealthcareHMS.Core;

public class DoctorWorkinghoursEntity
{
    public int Id {  get; set; }
    public Guid DoctorId { get; set; }
    public DoctorEntity Doctor { get; set; }
    public DayOfWeek Day {  get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}