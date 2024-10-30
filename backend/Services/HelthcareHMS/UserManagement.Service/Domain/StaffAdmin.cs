namespace UserManagement.Service.Domain;

public class StaffAdmin : User
{
    public Guid CreatedByGlobalAdminId { get; set; }
}