using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffMS.WebAPI.Domain.Additional;

namespace StaffMS.WebAPI.Infrastructure.Configurations.AdditionalEntitiesConfigs;

public class SpecialisationConfiguration: IEntityTypeConfiguration<SpecialisationEntity>
{
    public void Configure(EntityTypeBuilder<SpecialisationEntity> builder)
    {
        builder.HasKey(sp => sp.Id);

        builder.HasOne(sp => sp.StaffMember)
            .WithMany(s => s.Specialisations)
            .HasForeignKey(sp => sp.StaffId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}