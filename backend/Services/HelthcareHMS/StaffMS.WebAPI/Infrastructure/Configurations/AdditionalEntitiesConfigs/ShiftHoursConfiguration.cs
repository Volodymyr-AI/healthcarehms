using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffMS.WebAPI.Domain.Additional;

namespace StaffMS.WebAPI.Infrastructure.Configurations.AdditionalEntitiesConfigs;

public class ShiftHoursConfiguration: IEntityTypeConfiguration<ShiftHoursEntity>
{
    public void Configure(EntityTypeBuilder<ShiftHoursEntity> builder)
    {
        builder.HasKey(sh => sh.Id);

        builder.HasOne(sh => sh.StaffMember)
            .WithMany(s => s.WorkingHours)
            .HasForeignKey(sh => sh.StaffId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}