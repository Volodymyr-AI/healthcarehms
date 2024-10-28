namespace StaffMS.Core;

public class ServiceProvidedEntity
{
    public Guid Id { get; set; }
    public Guid StaffId { get; set; }
    public string ServiceName { get; set; }
    
    public StaffMemberEntity StaffMember { get; set; }    
}