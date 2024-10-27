using HealthcareHMS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareHMS.Persistence.Configurations.DoctorRelatedConfigurations;

public class LicenseConfiguration : IEntityTypeConfiguration<LicenseEntity>
{
    public void Configure(EntityTypeBuilder<LicenseEntity> builder)
    {
        /*
         * Primary Key
         */
        builder.HasKey(l => l.Id);

        /*
         * Foreign Key to DoctorEntity
         */
        builder.HasOne(l => l.Doctor)
            .WithMany(d => d.Licenses)
            .HasForeignKey(l => l.DoctorId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete if the doctor is deleted

        /*
         * Additional restrictions
         */
        builder.Property(l => l.License)
            .IsRequired()
            .HasMaxLength(100000);
    }
}