using StaffMS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareHMS.Persistence.Configurations.DoctorRelatedConfigurations;

public class ServicesProvidedConfiguration : IEntityTypeConfiguration<ServiceProvidedEntity>
{
    public void Configure(EntityTypeBuilder<ServiceProvidedEntity> builder)
    {
        /*
         * Primary Key
         */
        builder.HasKey(l => l.Id);

        /*
         * Foreign Key to StaffMemberEntity
         */
        builder.HasOne(l => l.StaffMember)
            .WithMany(d => d.ServicesProvided)
            .HasForeignKey(l => l.StaffId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete if the doctor is deleted

        /*
         * Additional restrictions
         */
        builder.Property(l => l.ServiceName)
            .IsRequired()
            .HasMaxLength(10000);
    }
}