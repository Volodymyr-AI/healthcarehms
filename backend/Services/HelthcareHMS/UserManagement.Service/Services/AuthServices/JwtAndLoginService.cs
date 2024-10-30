using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagement.Service.Domain;
using UserManagement.Service.Infrastructure;

namespace UserManagement.Service.Services.AuthServices;

public class JwtAndLoginService
{
    private readonly UserManagementDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly JwtService _jwtService;

    public JwtAndLoginService(UserManagementDbContext context, IPasswordHasher<User> passwordHasher, JwtService jwtService)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }

    public async Task<string> LoginAsync(string email, string password)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        
        if (user == null || _passwordHasher.VerifyHashedPassword(user, user.HashedPassword, password) == PasswordVerificationResult.Failed)
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }
        
        return _jwtService.GenerateToken(user);
    }
    
    public async Task<string> LoginStaffAdminAsync(string email, string password)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email && u.Role == "StaffAdmin");
    
        if (user == null || _passwordHasher.VerifyHashedPassword(user, user.HashedPassword, password) == PasswordVerificationResult.Failed)
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }
    
        return _jwtService.GenerateToken(user);
    }
    
    public async Task<string> LoginStaffMemberAsync(string email, string password)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email && u.Role == "StaffMember");
    
        if (user == null || _passwordHasher.VerifyHashedPassword(user, user.HashedPassword, password) == PasswordVerificationResult.Failed)
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }
    
        return _jwtService.GenerateToken(user);
    }
}