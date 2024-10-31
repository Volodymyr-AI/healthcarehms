﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StaffMS.WebAPI.Infrastructure;

#nullable disable

namespace StaffMS.WebAPI.Migrations
{
    [DbContext(typeof(StaffMSDbContext))]
    [Migration("20241031205422_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("StaffMS.WebAPI.Domain.Additional.CertificationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Certification")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Certifications");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.Additional.DepartmentFacilityEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Facility")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("DepartmentFacilities");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.Additional.DepartmentPhoneNumberEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("DepartmentPhoneNumbers");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.Additional.DepartmentServiceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("DepartmentServices");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.Additional.LicenseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("License")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.Additional.PractiseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Practise")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Practises");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.Additional.ServiceProvidedEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("ServiceProvided");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.Additional.ShiftHoursEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Day")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("WorkHours");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.Additional.SpecialisationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Speciality")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Specialisations");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.UserRelated.DepartmentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("AddGoogleMyBusiness")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("CloseTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GlobalAdminId")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("OpenTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ServicesAvailable")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GlobalAdminId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.UserRelated.GlobalAdminEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GlobalAdminEntity");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.UserRelated.StaffAdminEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId")
                        .IsUnique();

                    b.ToTable("StaffAdmins");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.UserRelated.StaffMemberEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("StaffMembers");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.Additional.CertificationEntity", b =>
                {
                    b.HasOne("StaffMS.WebAPI.Domain.UserRelated.StaffMemberEntity", "StaffMember")
                        .WithMany("Certifications")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.Additional.DepartmentFacilityEntity", b =>
                {
                    b.HasOne("StaffMS.WebAPI.Domain.UserRelated.DepartmentEntity", "Department")
                        .WithMany("DepartmentFacilities")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.Additional.DepartmentPhoneNumberEntity", b =>
                {
                    b.HasOne("StaffMS.WebAPI.Domain.UserRelated.DepartmentEntity", "Department")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.Additional.DepartmentServiceEntity", b =>
                {
                    b.HasOne("StaffMS.WebAPI.Domain.UserRelated.DepartmentEntity", "Department")
                        .WithMany("DepartmentServices")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.Additional.LicenseEntity", b =>
                {
                    b.HasOne("StaffMS.WebAPI.Domain.UserRelated.StaffMemberEntity", "StaffMember")
                        .WithMany("Licenses")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.Additional.PractiseEntity", b =>
                {
                    b.HasOne("StaffMS.WebAPI.Domain.UserRelated.StaffMemberEntity", "StaffMember")
                        .WithMany("Practises")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.Additional.ServiceProvidedEntity", b =>
                {
                    b.HasOne("StaffMS.WebAPI.Domain.UserRelated.StaffMemberEntity", "StaffMember")
                        .WithMany("ServicesProvided")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.Additional.ShiftHoursEntity", b =>
                {
                    b.HasOne("StaffMS.WebAPI.Domain.UserRelated.StaffMemberEntity", "StaffMember")
                        .WithMany("WorkingHours")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.Additional.SpecialisationEntity", b =>
                {
                    b.HasOne("StaffMS.WebAPI.Domain.UserRelated.StaffMemberEntity", "StaffMember")
                        .WithMany("Specialisations")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.UserRelated.DepartmentEntity", b =>
                {
                    b.HasOne("StaffMS.WebAPI.Domain.UserRelated.GlobalAdminEntity", null)
                        .WithMany()
                        .HasForeignKey("GlobalAdminId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.UserRelated.StaffAdminEntity", b =>
                {
                    b.HasOne("StaffMS.WebAPI.Domain.UserRelated.DepartmentEntity", "Department")
                        .WithOne("StaffAdmin")
                        .HasForeignKey("StaffMS.WebAPI.Domain.UserRelated.StaffAdminEntity", "DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.UserRelated.StaffMemberEntity", b =>
                {
                    b.HasOne("StaffMS.WebAPI.Domain.UserRelated.DepartmentEntity", "Department")
                        .WithMany("Staffmembers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.UserRelated.DepartmentEntity", b =>
                {
                    b.Navigation("DepartmentFacilities");

                    b.Navigation("DepartmentServices");

                    b.Navigation("PhoneNumbers");

                    b.Navigation("StaffAdmin")
                        .IsRequired();

                    b.Navigation("Staffmembers");
                });

            modelBuilder.Entity("StaffMS.WebAPI.Domain.UserRelated.StaffMemberEntity", b =>
                {
                    b.Navigation("Certifications");

                    b.Navigation("Licenses");

                    b.Navigation("Practises");

                    b.Navigation("ServicesProvided");

                    b.Navigation("Specialisations");

                    b.Navigation("WorkingHours");
                });
#pragma warning restore 612, 618
        }
    }
}