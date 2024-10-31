using StaffMS.WebAPI.Domain.UserRelated;

namespace StaffMS.WebAPI.Domain.Additional;

public class PractiseEntity
{
    public Guid Id { get; set; }
    public Guid StaffId { get; set; }
    public string Practise { get; set; }
    
    public StaffMemberEntity StaffMember { get; set; }
}