using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffMS.WebAPI.Domain.Additional;

namespace StaffMS.WebAPI.Infrastructure.Configurations.AdditionalEntitiesConfigs;

public class DepartmentServiceConfiguration : IEntityTypeConfiguration<DepartmentServiceEntity>
{
    public void Configure(EntityTypeBuilder<DepartmentServiceEntity> builder)
    {
        builder.HasKey(ds => ds.Id);

        builder.HasOne(ds => ds.Department)
            .WithMany(d => d.DepartmentServices)
            .HasForeignKey(ds => ds.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}