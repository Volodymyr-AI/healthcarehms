using StaffMS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareHMS.Persistence.Configurations.DoctorRelatedConfigurations;

public class ConditionTreatedConfiguration : IEntityTypeConfiguration<Specialisations>
{
    public void Configure(EntityTypeBuilder<Specialisations> builder)
    {
        /*
         * Primary Key
         */
        builder.HasKey(l => l.Id);

        /*
         * Foreign Key to StaffMemberEntity
         */
        builder.HasOne(l => l.StaffMember)
            .WithMany(d => d.Specialisations)
            .HasForeignKey(l => l.StaffId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete if the doctor is deleted

        /*
         * Additional restrictions
         */
        builder.Property(l => l.Condition)
            .IsRequired()
            .HasMaxLength(10000);
    }
}