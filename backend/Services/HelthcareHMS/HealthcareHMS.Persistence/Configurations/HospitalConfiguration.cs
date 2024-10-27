using HealthcareHMS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareHMS.Persistence.Configurations;

public class HospitalConfiguration : IEntityTypeConfiguration<HospitalEntity>
{
    public void Configure(EntityTypeBuilder<HospitalEntity> builder)
    {
        /*
         * Foreign key
         */
        builder.HasKey(x => x.Id);

        /*
         * One to One with HospitalAdminEntity
         */
        builder.HasOne(h => h.HospitalAdmin)
            .WithOne(h => h.Hospital)
            .HasForeignKey<HospitalAdminEntity>(a => a.HospitalId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete administrator if the hospital is deleted

        /*
         * One to many with DoctorEntity
         */
        builder.HasMany(h => h.Doctors)
            .WithOne(d => d.Hospital)
            .HasForeignKey(d => d.HospitalId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete doctors if the hospital is deleted
        
        /*
         * One-to-Many relationships for PhoneNumbers, FacilitiesAvailable, and ServicesProvided
         */
        builder.HasMany(h => h.PhoneNumbers)
            .WithOne(p => p.Hospital)
            .HasForeignKey(p => p.HospitalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(h => h.HospitalFacilities)
            .WithOne(f => f.Hospital)
            .HasForeignKey(f => f.HospitalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(h => h.HospitalServices)
            .WithOne(s => s.Hospital)
            .HasForeignKey(s => s.HospitalId)
            .OnDelete(DeleteBehavior.Cascade);
        /*
         * Additional restrictions
        **/
        builder.Property(h => h.HospitalName)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(h => h.Address)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(h => h.Email)
            .IsRequired()
            .HasMaxLength(100);
        
        // Connection with a global admin 
        builder.Property(h => h.GlobalAdminId)
            .IsRequired();
    }
}