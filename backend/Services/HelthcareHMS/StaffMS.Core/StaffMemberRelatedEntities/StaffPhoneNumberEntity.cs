namespace StaffMS.Core;

public class StaffPhoneNumberEntity
{
    public Guid Id { get; set; }
    public Guid StaffId { get; set; }
    public string PhoneNumber { get; set; }
    public StaffMemberEntity StaffMember { get; set; }
}