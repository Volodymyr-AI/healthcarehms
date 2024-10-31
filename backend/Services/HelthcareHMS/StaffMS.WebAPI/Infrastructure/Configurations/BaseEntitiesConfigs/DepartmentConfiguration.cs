using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffMS.WebAPI.Domain.UserRelated;

namespace StaffMS.WebAPI.Infrastructure.Configurations.BaseEntitiesConfigs;

public class DepartmentConfiguration: IEntityTypeConfiguration<DepartmentEntity>
{
    public void Configure(EntityTypeBuilder<DepartmentEntity> builder)
    {
        // Встановлення ключа
        builder.HasKey(d => d.Id);

        // Основні властивості
        builder.Property(d => d.DepartmentName)
               .IsRequired()
               .HasMaxLength(100);  // Наприклад, максимальна довжина 100 символів

        builder.Property(d => d.Address)
               .HasMaxLength(200);

        builder.Property(d => d.Email)
               .HasMaxLength(100);

        builder.Property(d => d.OpenTime)
               .IsRequired();

        builder.Property(d => d.CloseTime)
               .IsRequired();

        builder.Property(d => d.AddGoogleMyBusiness)
               .IsRequired();

        builder.Property(d => d.ServicesAvailable)
               .IsRequired();

        // Встановлення зв’язку з GlobalAdmin
        builder.HasOne<GlobalAdminEntity>()
               .WithMany()  // Assuming that GlobalAdmin can be related to multiple departments
               .HasForeignKey(d => d.GlobalAdminId)
               .OnDelete(DeleteBehavior.Restrict);

        // Встановлення зв’язку з StaffAdmin
        builder.HasOne(d => d.StaffAdmin)
               .WithOne()
               .HasForeignKey<DepartmentEntity>(d => d.GlobalAdminId)
               .OnDelete(DeleteBehavior.Restrict);

        // Встановлення зв’язку з StaffMemberEntity
        builder.HasMany(d => d.Staffmembers)
               .WithOne(s => s.Department)
               .HasForeignKey(s => s.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);

        // Налаштування зв’язку з DepartmentPhoneNumberEntity
        builder.HasMany(d => d.PhoneNumbers)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade);

        // Налаштування зв’язку з DepartmentFacilityEntity
        builder.HasMany(d => d.DepartmentFacilities)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade);

        // Налаштування зв’язку з DepartmentServiceEntity
        builder.HasMany(d => d.DepartmentServices)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade);
    }
}