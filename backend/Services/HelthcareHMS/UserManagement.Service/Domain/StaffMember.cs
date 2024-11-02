namespace UserManagement.Service.Domain;

public class StaffMember : User
{
    public Guid CreatedById { get; set; }
}