using StaffMS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareHMS.Persistence.Configurations;

public class WorkingHoursConfiguration : IEntityTypeConfiguration<StaffWorkinghoursEntity>
{
    public void Configure(EntityTypeBuilder<StaffWorkinghoursEntity> builder)
    {
        /*
         * Primary key
         */
        builder.HasKey(x => x.Id);

        /*
         * Many to One with StaffMemberEntity
         */
        builder.HasOne(w => w.StaffMember)
            .WithMany(d => d.WorkingHours)
            .HasForeignKey(d => d.StaffId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delte of shift hours if doctor is deleted

        // Additional restrictions
        builder.Property(w => w.Day)
            .IsRequired();

        builder.Property(w => w.StartTime)
            .IsRequired();

        builder.Property(w => w.EndTime)
            .IsRequired();
    }
}