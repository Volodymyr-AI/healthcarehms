using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Service.Domain;

namespace UserManagement.Service.Infrastructure.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UserId);
        builder.Property(u => u.Email).IsRequired();
        builder.Property(u => u.Login).IsRequired();
        builder.Property(u => u.HashedPassword).IsRequired();
        builder.Property(u => u.Role).IsRequired();
        
        builder.HasDiscriminator<string>("Role")
            .HasValue<GlobalAdmin>("GlobalAdmin")
            .HasValue<StaffAdmin>("StaffAdmin")
            .HasValue<StaffMember>("StaffMember");
    }
}