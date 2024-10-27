using HealthcareHMS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareHMS.Persistence.Configurations;

public class WorkingHoursConfiguration : IEntityTypeConfiguration<DoctorWorkinghoursEntity>
{
    public void Configure(EntityTypeBuilder<DoctorWorkinghoursEntity> builder)
    {
        /*
         * Primary key
         */
        builder.HasKey(x => x.Id);

        /*
         * Many to One with DoctorEntity
         */
        builder.HasOne(w => w.Doctor)
            .WithMany(d => d.WorkingHours)
            .HasForeignKey(d => d.DoctorId)
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