using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffMS.WebAPI.Domain.Additional;

namespace StaffMS.WebAPI.Infrastructure.Configurations.AdditionalEntitiesConfigs;

public class PractiseConfiguration: IEntityTypeConfiguration<PractiseEntity>
{
    public void Configure(EntityTypeBuilder<PractiseEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.StaffMember)
            .WithMany(s => s.Practises)
            .HasForeignKey(p => p.StaffId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}