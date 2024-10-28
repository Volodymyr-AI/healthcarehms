using StaffMS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareHMS.Persistence.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<DepartmentEntity>
{
    public void Configure(EntityTypeBuilder<DepartmentEntity> builder)
    {
        /*
         * Foreign key
         */
        builder.HasKey(x => x.Id);

        /*
         * One to One with StaffAdminEntity
         */
        builder.HasOne(h => h.StaffAdmin)
            .WithOne(h => h.Department)
            .HasForeignKey<StaffAdminEntity>(a => a.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete administrator if the hospital is deleted

        /*
         * One to many with StaffMemberEntity
         */
        builder.HasMany(h => h.Staffmembers)
            .WithOne(d => d.Department)
            .HasForeignKey(d => d.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete doctors if the hospital is deleted
        
        /*
         * One-to-Many relationships for PhoneNumbers, FacilitiesAvailable, and ServicesProvided
         */
        builder.HasMany(h => h.PhoneNumbers)
            .WithOne(p => p.Department)
            .HasForeignKey(p => p.HospitalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(h => h.DepartmentFacilities)
            .WithOne(f => f.Department)
            .HasForeignKey(f => f.HospitalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(h => h.DepartmentServices)
            .WithOne(s => s.Department)
            .HasForeignKey(s => s.HospitalId)
            .OnDelete(DeleteBehavior.Cascade);
        /*
         * Additional restrictions
        **/
        builder.Property(h => h.DepartmentName)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(h => h.Address)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(h => h.Email)
            .IsRequired()
            .HasMaxLength(100);
        
        // Connection with a global admin 
        builder.Property(h => h.GlobalAdminId)
            .IsRequired();
    }
}