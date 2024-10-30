using Microsoft.AspNetCore.Identity;
using UserManagement.Service.Domain;
using UserManagement.Service.Infrastructure;

namespace UserManagement.Service.Services.UserServices;

public class StaffAdminService
{
    private readonly UserManagementDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;

    public StaffAdminService(UserManagementDbContext context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task<StaffAdmin> RegisterStaffAdminAsync(string email, string login, string password, Guid createdByGlobalAdminId)
    {
        var staffAdmin = new StaffAdmin
        {
            Email = email,
            Login = login,
            Role = "StaffAdmin",
            CreatedByGlobalAdminId = createdByGlobalAdminId // Зберігаємо ID глобального адміністратора, який створив цього адміністратора
        };

        staffAdmin.HashedPassword = _passwordHasher.HashPassword(staffAdmin, password);

        _context.Users.Add(staffAdmin);
        await _context.SaveChangesAsync();
        
        return staffAdmin;
    }
}