using HealthcareHMS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace HealthcareHMS.Persistence.Configurations;

public class HospitalAdminConfiguration : IEntityTypeConfiguration<HospitalAdminEntity>
{
    public void Configure(EntityTypeBuilder<HospitalAdminEntity> builder)
    {
        /*
         * Primary Key
         */
        builder.HasKey(x => x.HospitalAdminId);

        /*
         * One to One with HospitalEntity
         */
        builder.HasOne(admin => admin.Hospital)
            .WithOne(hospital => hospital.HospitalAdmin)
            .HasForeignKey<HospitalAdminEntity>(admin => admin.HospitalAdminId)
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