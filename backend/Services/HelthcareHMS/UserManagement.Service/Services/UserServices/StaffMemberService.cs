using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagement.Service.Domain;
using UserManagement.Service.Infrastructure;

namespace UserManagement.Service.Services.UserServices;

public class StaffMemberService
{
    private readonly UserManagementDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;

    public StaffMemberService(UserManagementDbContext context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task<StaffMember> RegisterStaffMemberAsync(string email, string login, string password, Guid createdById)
    {
        var staffMember = new StaffMember
        {
            Email = email,
            Login = login,
            CreatedById = createdById
        };

        staffMember.HashedPassword = _passwordHasher.HashPassword(staffMember, password);

        _context.Users.Add(staffMember);
        await _context.SaveChangesAsync();
        
        return staffMember;
    }
    
    public async Task<List<StaffMember>> GetAllStaffMembersAsync()
    {
        return await _context.Users
            .OfType<StaffMember>()
            .OrderBy(ga => ga.UserId)
            .Select(ga => new StaffMember
            {
                UserId = ga.UserId,
                Email = ga.Email,
                Login = ga.Login,
                Role = ga.Role
            })
            .ToListAsync();
    }
    
    public async Task<StaffMember?> GetStaffMemberByIdAsync(Guid id)
    {
        return await _context.Users.OfType<StaffMember>().FirstOrDefaultAsync(sm => sm.UserId == id);
    }
    
    public async Task<bool> UpdateStaffMemberEmailAsync(Guid id, string newEmail)
    {
        var staffMember = await GetStaffMemberByIdAsync(id);
        if (staffMember == null) return false;

        staffMember.Email = newEmail;
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> UpdateStaffMemberPasswordAsync(Guid id, string newPassword)
    {
        var staffMember = await GetStaffMemberByIdAsync(id);
        if (staffMember == null) return false;

        staffMember.HashedPassword = _passwordHasher.HashPassword(staffMember, newPassword);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> DeleteStaffMemberAsync(Guid id)
    {
        var staffMember = await GetStaffMemberByIdAsync(id);
        if (staffMember == null) return false;

        _context.Users.Remove(staffMember);
        await _context.SaveChangesAsync();
        return true;
    }
}