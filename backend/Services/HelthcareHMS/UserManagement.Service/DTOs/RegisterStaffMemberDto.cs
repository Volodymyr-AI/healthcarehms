namespace UserManagement.Service.DTOs;

public class RegisterStaffMemberDto
{
    public string Email { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public Guid CreatedById { get; set; }
}