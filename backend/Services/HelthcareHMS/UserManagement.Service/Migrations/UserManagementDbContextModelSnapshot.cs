﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagement.Service.Infrastructure;

#nullable disable

namespace UserManagement.Service.Migrations
{
    [DbContext(typeof(UserManagementDbContext))]
    partial class UserManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("UserManagement.Service.Domain.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Role").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("UserManagement.Service.Domain.GlobalAdmin", b =>
                {
                    b.HasBaseType("UserManagement.Service.Domain.User");

                    b.HasDiscriminator().HasValue("GlobalAdmin");
                });

            modelBuilder.Entity("UserManagement.Service.Domain.StaffAdmin", b =>
                {
                    b.HasBaseType("UserManagement.Service.Domain.User");

                    b.Property<Guid>("CreatedByGlobalAdminId")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("StaffAdmin");
                });

            modelBuilder.Entity("UserManagement.Service.Domain.StaffMember", b =>
                {
                    b.HasBaseType("UserManagement.Service.Domain.User");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("StaffMember");
                });
#pragma warning restore 612, 618
        }
    }
}
