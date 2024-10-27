using HealthcareHMS.Core.HospitalRelatedEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareHMS.Persistence.Configurations.HospitalRelatedConfigurattions;

public class HospitalServiceConfiguration : IEntityTypeConfiguration<HospitalServiceEntity>
{
    public void Configure(EntityTypeBuilder<HospitalServiceEntity> builder)
    {
        /*
         * Primary Key
         */
        builder.HasKey(l => l.Id);

        /*
         * Foreign Key to Hospital
         */
        builder.HasOne(l => l.Hospital)
            .WithMany(d => d.HospitalServices)
            .HasForeignKey(l => l.Id)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete if the hospital is deleted

        /*
         * Additional restrictions
         */
        builder.Property(l => l.Service)
            .IsRequired()
            .HasMaxLength(10000);
    }
}