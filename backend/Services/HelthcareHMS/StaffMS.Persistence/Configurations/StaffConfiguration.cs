using StaffMS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace HealthcareHMS.Persistence.Configurations;

public class StaffConfiguration : IEntityTypeConfiguration<StaffMemberEntity>
{
    public void Configure(EntityTypeBuilder<StaffMemberEntity> builder)
    {
        /*
         * Primary key
         */
        builder.HasKey(x => x.StaffId);

        /*
         * One to Many with DepartmentEntity
         */
        builder.HasOne(d => d.Department)
            .WithMany(h => h.Staffmembers)
            .HasForeignKey(d => d.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade); // cascade delete of the doctor if hospital is deleted

        /*
         * One to Many with WorkingHoursEntity
         */
        builder.HasMany(d => d.WorkingHours)
            .WithOne(w => w.StaffMember)
            .HasForeignKey(w => w.StaffId)
            .OnDelete(DeleteBehavior.Cascade); // cascade delete of shift hours if doctor is deleted
        
        /*
         * One-to-Many relationships for Licenses, Certifications, Conditions, Practises, and ServiceProvided
         */
        builder.HasMany(d => d.Licenses)
            .WithOne(l => l.StaffMember)
            .HasForeignKey(l => l.StaffId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.Certifications)
            .WithOne(c => c.StaffMember)
            .HasForeignKey(c => c.StaffId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.Specialisations)
            .WithOne(ct => ct.StaffMember)
            .HasForeignKey(ct => ct.StaffId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.Practises)
            .WithOne(p => p.StaffMember)
            .HasForeignKey(p => p.StaffId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.ServicesProvided)
            .WithOne(sp => sp.StaffMember)
            .HasForeignKey(sp => sp.StaffId)
            .OnDelete(DeleteBehavior.Cascade);

        // Additional restrictions
        builder.Property(d => d.StaffName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Specialization)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Bio)
            .HasMaxLength(10000);

        builder.Property(d => d.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Login)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(d => d.Password)
            .IsRequired()
            .HasMaxLength(50);
    }
}