using StaffMS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace HealthcareHMS.Persistence.Configurations;

public class StaffAdminConfiguration : IEntityTypeConfiguration<StaffAdminEntity>
{
    public void Configure(EntityTypeBuilder<StaffAdminEntity> builder)
    {
        /*
         * Primary Key
         */
        builder.HasKey(x => x.StaffAdminId);

        /*
         * One to One with DepartmentEntity
         */
        builder.HasOne(admin => admin.Department)
            .WithOne(hospital => hospital.StaffAdmin)
            .HasForeignKey<StaffAdminEntity>(admin => admin.StaffAdminId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete of administrator if the hospital being deleted

        // Additional restrictions
        builder.Property(x => x.Login)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.AdminName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Password)
            .IsRequired();

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);
    }
}