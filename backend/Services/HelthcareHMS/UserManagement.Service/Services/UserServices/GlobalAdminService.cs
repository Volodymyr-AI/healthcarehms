using Microsoft.AspNetCore.Identity;
using UserManagement.Service.Domain;
using UserManagement.Service.Infrastructure;

namespace UserManagement.Service.Services.UserServices;

public class GlobalAdminService
{
    private readonly UserManagementDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;

    public GlobalAdminService(UserManagementDbContext context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task<GlobalAdmin> RegisterGlobalAdminAsync(string email, string login, string password)
    {
        var globalAdmin = new GlobalAdmin
        {
            Email = email,
            Login = login,
            Role = "GlobalAdmin",
        };
        
        globalAdmin.HashedPassword = _passwordHasher.HashPassword(globalAdmin, password);

        _context.Users.Add(globalAdmin);
        await _context.SaveChangesAsync();
        
        return globalAdmin;
    }
}