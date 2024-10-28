namespace StaffMS.Core;

public class Specialisations
{
    public Guid Id { get; set; }
    public Guid StaffId { get; set; }
    public string Condition { get; set; }
    
    public StaffMemberEntity StaffMember { get; set; }
}