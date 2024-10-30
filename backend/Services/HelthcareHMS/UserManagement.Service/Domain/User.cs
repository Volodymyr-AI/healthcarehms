namespace UserManagement.Service.Domain;

public abstract class User
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Email { get; set; }
    public string Login { get; set; }
    public string HashedPassword { get; set; }
    public string Role { get; set; }
}