using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffMS.WebAPI.Domain.UserRelated;

namespace StaffMS.WebAPI.Infrastructure.Configurations.BaseEntitiesConfigs;

public class StaffAdminConfiguration: IEntityTypeConfiguration<StaffAdminEntity>
{
    public void Configure(EntityTypeBuilder<StaffAdminEntity> builder)
    {
        // Встановлення ключа
        builder.HasKey(s => s.Id);

        // Основні властивості
        builder.Property(s => s.AdminName)
            .HasMaxLength(100); // Максимальна довжина для імені адміністратора

        // Зв’язок з DepartmentEntity
        builder.HasOne(s => s.Department)
            .WithOne(d => d.StaffAdmin)
            .HasForeignKey<StaffAdminEntity>(s => s.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict); // Вибираємо DeleteBehavior.Restrict для уникнення циклічних видалень
    }
}