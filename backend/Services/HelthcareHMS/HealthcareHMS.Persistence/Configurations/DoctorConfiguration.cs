using HealthcareHMS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace HealthcareHMS.Persistence.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<DoctorEntity>
{
    public void Configure(EntityTypeBuilder<DoctorEntity> builder)
    {
        /*
         * Primary key
         */
        builder.HasKey(x => x.DoctorId);

        /*
         * One to Many with HospitalEntity
         */
        builder.HasOne(d => d.Hospital)
            .WithMany(h => h.Doctors)
            .HasForeignKey(d => d.HospitalId)
            .OnDelete(DeleteBehavior.Cascade); // cascade delete of the doctor if hospital is deleted

        /*
         * One to Many with WorkingHoursEntity
         */
        builder.HasMany(d => d.WorkingHours)
            .WithOne(w => w.Doctor)
            .HasForeignKey(w => w.DoctorId)
            .OnDelete(DeleteBehavior.Cascade); // cascade delete of shift hours if doctor is deleted


        // Additional restrictions
        builder.Property(d => d.DoctorName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Specialization)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Bio)
            .HasMaxLength(10000);
    }
}