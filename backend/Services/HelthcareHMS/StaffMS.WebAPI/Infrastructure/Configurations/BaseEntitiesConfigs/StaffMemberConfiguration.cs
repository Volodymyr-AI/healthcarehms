using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffMS.WebAPI.Domain.UserRelated;

namespace StaffMS.WebAPI.Infrastructure.Configurations.BaseEntitiesConfigs;

public class StaffMemberConfiguration: IEntityTypeConfiguration<StaffMemberEntity>
{
    public void Configure(EntityTypeBuilder<StaffMemberEntity> builder)
    {
        // Встановлення ключа
        builder.HasKey(s => s.Id);

        // Основні властивості
        builder.Property(s => s.StaffName)
            .HasMaxLength(100);

        builder.Property(s => s.Specialization)
            .HasMaxLength(100);

        builder.Property(s => s.Bio)
            .HasMaxLength(500); // Максимальна довжина для біографії

        //builder.Property(s => s.YearsOfExperience)
        //    .IsRequired();

        builder.Property(s => s.School)
            .HasMaxLength(100);

        // Зв’язок з DepartmentEntity
        builder.HasOne(s => s.Department)
            .WithMany(d => d.Staffmembers)
            .HasForeignKey(s => s.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Зв’язок з LicenseEntity
        builder.HasMany(s => s.Licenses)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        // Зв’язок з CertificationEntity
        builder.HasMany(s => s.Certifications)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        // Зв’язок з SpecialisationEntity
        builder.HasMany(s => s.Specialisations)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        // Зв’язок з PractiseEntity
        builder.HasMany(s => s.Practises)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        // Зв’язок з ServiceProvidedEntity
        builder.HasMany(s => s.ServicesProvided)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        // Зв’язок з ShiftHoursEntity для робочих годин
        builder.HasMany(s => s.WorkingHours)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}