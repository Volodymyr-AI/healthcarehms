using Microsoft.EntityFrameworkCore;
using UserManagement.Service.Domain;
using UserManagement.Service.Infrastructure.Configurations;

namespace UserManagement.Service.Infrastructure;

public class UserManagementDbContext : DbContext
{
    public DbSet<User> Users { get; set; } 
    
    public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new StaffAdminConfiguration());
        modelBuilder.ApplyConfiguration(new StaffMemberConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}