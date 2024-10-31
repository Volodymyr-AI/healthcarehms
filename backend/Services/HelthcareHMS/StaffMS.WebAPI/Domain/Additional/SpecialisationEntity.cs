using StaffMS.WebAPI.Domain.UserRelated;

namespace StaffMS.WebAPI.Domain.Additional;

public class SpecialisationEntity
{
    public Guid Id { get; set; }
    public Guid StaffId { get; set; }
    public string Speciality { get; set; }
    
    public StaffMemberEntity StaffMember { get; set; }
}