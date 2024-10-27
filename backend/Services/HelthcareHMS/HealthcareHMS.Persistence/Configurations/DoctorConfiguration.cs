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
        
        /*
         * One-to-Many relationships for Licenses, Certifications, Conditions, Practises, and ServiceProvided
         */
        builder.HasMany(d => d.Licenses)
            .WithOne(l => l.Doctor)
            .HasForeignKey(l => l.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.Certifications)
            .WithOne(c => c.Doctor)
            .HasForeignKey(c => c.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.Conditions)
            .WithOne(ct => ct.Doctor)
            .HasForeignKey(ct => ct.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.Practises)
            .WithOne(p => p.Doctor)
            .HasForeignKey(p => p.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.ServicesProvided)
            .WithOne(sp => sp.Doctor)
            .HasForeignKey(sp => sp.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        // Additional restrictions
        builder.Property(d => d.DoctorName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Specialization)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Bio)
            .HasMaxLength(10000);

        builder.Property(d => d.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Login)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(d => d.Password)
            .IsRequired()
            .HasMaxLength(50);
    }
}