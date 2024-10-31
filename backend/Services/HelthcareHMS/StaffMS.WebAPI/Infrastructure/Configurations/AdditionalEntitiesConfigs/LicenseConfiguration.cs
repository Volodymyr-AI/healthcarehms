using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffMS.WebAPI.Domain.Additional;

namespace StaffMS.WebAPI.Infrastructure.Configurations.AdditionalEntitiesConfigs;

public class LicenseConfiguration: IEntityTypeConfiguration<LicenseEntity>
{
    public void Configure(EntityTypeBuilder<LicenseEntity> builder)
    {
        builder.HasKey(l => l.Id);

        builder.HasOne(l => l.StaffMember)
            .WithMany(s => s.Licenses)
            .HasForeignKey(l => l.StaffId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}