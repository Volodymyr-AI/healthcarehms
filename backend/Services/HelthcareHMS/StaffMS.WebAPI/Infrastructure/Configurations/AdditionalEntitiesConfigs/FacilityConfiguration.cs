using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffMS.WebAPI.Domain.Additional;

namespace StaffMS.WebAPI.Infrastructure.Configurations.AdditionalEntitiesConfigs;

public class FacilityConfiguration: IEntityTypeConfiguration<DepartmentFacilityEntity>
{
    public void Configure(EntityTypeBuilder<DepartmentFacilityEntity> builder)
    {
        builder.HasKey(df => df.Id);

        builder.HasOne(df => df.Department)
            .WithMany(d => d.DepartmentFacilities)
            .HasForeignKey(df => df.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}