using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Service.Domain;

namespace UserManagement.Service.Infrastructure.Configurations;

public class StaffAdminConfiguration : IEntityTypeConfiguration<StaffAdmin>
{
    public void Configure(EntityTypeBuilder<StaffAdmin> builder)
    {
        builder.Property(sa => sa.CreatedByGlobalAdminId).IsRequired();
    }
}