using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
    public async Task<GlobalAdmin?> GetGlobalAdminByIdAsync(Guid id)
    {
        return await _context.Users.OfType<GlobalAdmin>().FirstOrDefaultAsync(ga => ga.UserId == id);
    }

    public async Task<List<GlobalAdmin>> GetAllGlobalAdmin()
    {
        return await _context.Users.OfType<GlobalAdmin>().OrderBy(ga => ga.UserId).ToListAsync();
    }

    public async Task<GlobalAdmin?> GetGlobalAdminByEmailAsync(string email)
    {
        return await _context.Users.OfType<GlobalAdmin>().FirstOrDefaultAsync(ga => ga.Email == email);
    }

    public async Task<bool> UpdateGlobalAdminEmailAsync(Guid id, string newEmail)
    {
        var globalAdmin = await GetGlobalAdminByIdAsync(id);
        if (globalAdmin == null) return false;

        globalAdmin.Email = newEmail;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateGlobalAdminPasswordAsync(Guid id, string newPassword)
    {
        var globalAdmin = await GetGlobalAdminByIdAsync(id);
        if (globalAdmin == null) return false;

        globalAdmin.HashedPassword = _passwordHasher.HashPassword(globalAdmin, newPassword);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteGlobalAdminAsync(Guid id)
    {
        var globalAdmin = await GetGlobalAdminByIdAsync(id);
        if (globalAdmin == null) return false;

        _context.Users.Remove(globalAdmin);
        await _context.SaveChangesAsync();
        return true;
    }
}