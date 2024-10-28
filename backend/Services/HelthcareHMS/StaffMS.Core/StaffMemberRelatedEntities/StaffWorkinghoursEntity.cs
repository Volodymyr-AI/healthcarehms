namespace StaffMS.Core;

public class StaffWorkinghoursEntity
{
    public Guid Id {  get; set; }
    public Guid StaffId { get; set; }
    public StaffMemberEntity StaffMember { get; set; }
    public DayOfWeek Day {  get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}