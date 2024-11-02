using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            CreatedByGlobalAdminId = createdByGlobalAdminId 
        };

        staffAdmin.HashedPassword = _passwordHasher.HashPassword(staffAdmin, password);

        _context.Users.Add(staffAdmin);
        await _context.SaveChangesAsync();
        
        return staffAdmin;
    }

    public async Task<StaffAdmin?> GetStaffAdminByIdAsync(Guid id)
    {
        return await _context.Users.OfType<StaffAdmin>().FirstOrDefaultAsync(sa => sa.UserId == id);
    }


    public async Task<bool> UpdateStaffAdminEmailAsync(Guid id, string newEmail)
    {
        var staffAdmin = await GetStaffAdminByIdAsync(id);
        if (staffAdmin == null) return false;

        staffAdmin.Email = newEmail;
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> UpdateStaffAdminPasswordAsync(Guid id, string newPassword)
    {
        var staffAdmin = await GetStaffAdminByIdAsync(id);
        if (staffAdmin == null) return false;

        staffAdmin.HashedPassword = _passwordHasher.HashPassword(staffAdmin, newPassword);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteStaffAdminAsync(Guid id)
    {
        var staffAdmin = await GetStaffAdminByIdAsync(id);
        if (staffAdmin == null) return false;

        _context.Users.Remove(staffAdmin);
        await _context.SaveChangesAsync();
        return true;
    }
}