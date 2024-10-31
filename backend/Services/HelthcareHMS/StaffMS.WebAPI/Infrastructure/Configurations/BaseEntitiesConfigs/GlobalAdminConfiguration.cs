using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffMS.WebAPI.Domain.UserRelated;

namespace StaffMS.WebAPI.Infrastructure.Configurations.BaseEntitiesConfigs;

public class GlobalAdminConfiguration: IEntityTypeConfiguration<GlobalAdminEntity>
{
    public void Configure(EntityTypeBuilder<GlobalAdminEntity> builder)
    {
        // Встановлення ключа
        builder.HasKey(g => g.Id);

        // Встановлення полів
        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(100); // Наприклад, обмеження довжини імені

        builder.Property(g => g.Phone)
            .IsRequired()
            .HasMaxLength(15); // Можливе обмеження для номеру телефону

        // Додаткові конфігурації за необхідності
    }
}