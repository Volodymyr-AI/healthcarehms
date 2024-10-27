﻿using HealthcareHMS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareHMS.Persistence.Configurations.DoctorRelatedConfigurations;

public class PractiseConfiguration : IEntityTypeConfiguration<PractiseEntity>
{
    public void Configure(EntityTypeBuilder<PractiseEntity> builder)
    {
        /*
         * Primary Key
         */
        builder.HasKey(l => l.Id);

        /*
         * Foreign Key to DoctorEntity
         */
        builder.HasOne(l => l.Doctor)
            .WithMany(d => d.Practises)
            .HasForeignKey(l => l.DoctorId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete if the doctor is deleted

        /*
         * Additional restrictions
         */
        builder.Property(l => l.Practise)
            .IsRequired()
            .HasMaxLength(10000);
    }
}