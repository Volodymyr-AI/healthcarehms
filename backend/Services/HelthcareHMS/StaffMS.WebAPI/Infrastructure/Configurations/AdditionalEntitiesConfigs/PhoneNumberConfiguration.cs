using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaffMS.WebAPI.Domain.Additional;

namespace StaffMS.WebAPI.Infrastructure.Configurations.AdditionalEntitiesConfigs;

public class PhoneNumberConfiguration: IEntityTypeConfiguration<DepartmentPhoneNumberEntity>
{
    public void Configure(EntityTypeBuilder<DepartmentPhoneNumberEntity> builder)
    {
        builder.HasKey(dp => dp.Id);

        builder.HasOne(dp => dp.Department)
            .WithMany(d => d.PhoneNumbers)
            .HasForeignKey(dp => dp.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}