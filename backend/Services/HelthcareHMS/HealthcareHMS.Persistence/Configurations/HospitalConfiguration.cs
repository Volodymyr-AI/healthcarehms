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

        builder.Property(h => h.PhoneNumbers)
            .HasConversion(
                v => string.Join(";", v),// Save list of phonenumbers as a string
                v => v.Split(new[] { ';' }, StringSplitOptions.None).ToList());// Back to list


        builder.Property(h => h.FacilitiesAvailable)
            .HasMaxLength(500);

        builder.Property(h => h.ServicesProvided)
            .HasMaxLength(500);

        // Connection with a global admin 
        builder.Property(h => h.GlobalAdminId)
            .IsRequired();
    }
}