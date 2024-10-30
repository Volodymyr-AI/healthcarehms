namespace StaffMS.Core;

public class StaffAdminEntity
{
    public Guid StaffAdminId { get; set; }
    public string AdminName { get; set; }
    public string Email {  get; set; }
    public string Login {  get; set; }
    public string Password { get; set; }

    // Connection with the hospital
    public Guid DepartmentId { get; set; }
    public DepartmentEntity Department { get; set; }
}