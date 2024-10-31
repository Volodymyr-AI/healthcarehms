using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffMS.WebAPI.Domain.Additional;

namespace StaffMS.WebAPI.Infrastructure.Configurations.AdditionalEntitiesConfigs;

public class StaffServiceConfiguration: IEntityTypeConfiguration<ServiceProvidedEntity>
{
    public void Configure(EntityTypeBuilder<ServiceProvidedEntity> builder)
    {
        builder.HasKey(sp => sp.Id);

        builder.HasOne(sp => sp.StaffMember)
            .WithMany(s => s.ServicesProvided)
            .HasForeignKey(sp => sp.StaffId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}