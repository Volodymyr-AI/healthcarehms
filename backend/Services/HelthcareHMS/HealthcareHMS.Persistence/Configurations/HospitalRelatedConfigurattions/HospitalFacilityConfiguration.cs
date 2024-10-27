using HealthcareHMS.Core.HospitalRelatedEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareHMS.Persistence.Configurations.HospitalRelatedConfigurattions;

public class HospitalFacilityConfiguration : IEntityTypeConfiguration<HospitalFacilityEntity>
{
    public void Configure(EntityTypeBuilder<HospitalFacilityEntity> builder)
    {
        /*
         * Primary Key
         */
        builder.HasKey(l => l.Id);

        /*
         * Foreign Key to Hospital
         */
        builder.HasOne(l => l.Hospital)
            .WithMany(d => d.HospitalFacilities)
            .HasForeignKey(l => l.Id)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete if the hospital is deleted

        /*
         * Additional restrictions
         */
        builder.Property(l => l.Facility)
            .IsRequired()
            .HasMaxLength(10000);
    }
}