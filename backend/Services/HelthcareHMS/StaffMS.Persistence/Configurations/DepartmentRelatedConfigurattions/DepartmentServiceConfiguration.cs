using StaffMS.Core.HospitalRelatedEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareHMS.Persistence.Configurations.HospitalRelatedConfigurattions;

public class DepartmentServiceConfiguration : IEntityTypeConfiguration<DepartmentServiceEntity>
{
    public void Configure(EntityTypeBuilder<DepartmentServiceEntity> builder)
    {
        /*
         * Primary Key
         */
        builder.HasKey(l => l.Id);

        /*
         * Foreign Key to Department
         */
        builder.HasOne(l => l.Department)
            .WithMany(d => d.DepartmentServices)
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