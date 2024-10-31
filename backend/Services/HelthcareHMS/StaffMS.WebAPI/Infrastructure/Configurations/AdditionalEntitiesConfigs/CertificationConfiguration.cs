using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffMS.WebAPI.Domain.Additional;

namespace StaffMS.WebAPI.Infrastructure.Configurations.AdditionalEntitiesConfigs;

public class CertificationConfiguration : IEntityTypeConfiguration<CertificationEntity>
{
    public void Configure(EntityTypeBuilder<CertificationEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.StaffMember)
            .WithMany(s => s.Certifications)
            .HasForeignKey(c => c.StaffId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}