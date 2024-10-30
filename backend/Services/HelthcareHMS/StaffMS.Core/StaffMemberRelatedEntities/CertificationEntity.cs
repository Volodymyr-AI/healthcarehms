namespace StaffMS.Core;

public class CertificationEntity
{
    public Guid Id { get; set; }
    public Guid StaffId { get; set; }
    public string Certification { get; set; }
    
    public StaffMemberEntity StaffMember { get; set; }
}