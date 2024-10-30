using Microsoft.AspNetCore.Identity;
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
}