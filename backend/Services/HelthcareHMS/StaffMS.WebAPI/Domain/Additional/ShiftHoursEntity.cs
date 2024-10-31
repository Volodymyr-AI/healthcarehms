using StaffMS.WebAPI.Domain.UserRelated;

namespace StaffMS.WebAPI.Domain.Additional;

public class ShiftHoursEntity
{
    public Guid Id {  get; set; }
    public Guid StaffId { get; set; }
    public StaffMemberEntity StaffMember { get; set; }
    public DayOfWeek Day {  get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}