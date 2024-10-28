using StaffMS.Core.HospitalRelatedEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareHMS.Persistence.Configurations.HospitalRelatedConfigurattions;

public class DepartmentPhoneNumberConfiguration : IEntityTypeConfiguration<DepartmentPhoneNumberEntity>
{
    public void Configure(EntityTypeBuilder<DepartmentPhoneNumberEntity> builder)
    {
        /*
         * Primary Key
         */
        builder.HasKey(l => l.Id);

        /*
         * Foreign Key to Department
         */
        builder.HasOne(l => l.Department)
            .WithMany(d => d.PhoneNumbers)
            .HasForeignKey(l => l.Id)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete if the hospital is deleted

        /*
         * Additional restrictions
         */
        builder.Property(l => l.PhoneNumber)
            .IsRequired()
            .HasMaxLength(10000);
    }
}