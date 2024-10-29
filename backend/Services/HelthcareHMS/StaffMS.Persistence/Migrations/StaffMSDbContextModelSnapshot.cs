﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StaffMS.Persistence;

#nullable disable

namespace StaffMS.Persistence.Migrations
{
    [DbContext(typeof(StaffMSDbContext))]
    partial class StaffMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("StaffMS.Core.CertificationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Certification")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Certifications");
                });

            modelBuilder.Entity("StaffMS.Core.DepartmentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("AddGoogleMyBusiness")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("CloseTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(150)
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

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("StaffMS.Core.HospitalRelatedEntities.DepartmentFacilityEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Facility")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("HospitalId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DepartmentFacilities");
                });

            modelBuilder.Entity("StaffMS.Core.HospitalRelatedEntities.DepartmentPhoneNumberEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("HospitalId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DepartmentPhoneNumbers");
                });

            modelBuilder.Entity("StaffMS.Core.HospitalRelatedEntities.DepartmentServiceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("HospitalId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DepartmentServices");
                });

            modelBuilder.Entity("StaffMS.Core.LicenseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("License")
                        .IsRequired()
                        .HasMaxLength(100000)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("StaffMS.Core.PractiseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Practise")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Practises");
                });

            modelBuilder.Entity("StaffMS.Core.ServiceProvidedEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("ServiceProvided");
                });

            modelBuilder.Entity("StaffMS.Core.Specialisations", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Specialisations");
                });

            modelBuilder.Entity("StaffMS.Core.StaffAdminEntity", b =>
                {
                    b.Property<Guid>("StaffAdminId")
                        .HasColumnType("TEXT");

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StaffAdminId");

                    b.ToTable("StaffAdmins");
                });

            modelBuilder.Entity("StaffMS.Core.StaffMemberEntity", b =>
                {
                    b.Property<Guid>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Appointment_Availability")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("School")
                        .IsRequired()
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

                    b.HasKey("StaffId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("StaffMembers");
                });

            modelBuilder.Entity("StaffMS.Core.StaffPhoneNumberEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StaffMemberStaffId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StaffMemberStaffId");

                    b.ToTable("StaffPhoneNumbers");
                });

            modelBuilder.Entity("StaffMS.Core.StaffWorkinghoursEntity", b =>
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

            modelBuilder.Entity("StaffMS.Core.CertificationEntity", b =>
                {
                    b.HasOne("StaffMS.Core.StaffMemberEntity", "StaffMember")
                        .WithMany("Certifications")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("StaffMS.Core.HospitalRelatedEntities.DepartmentFacilityEntity", b =>
                {
                    b.HasOne("StaffMS.Core.DepartmentEntity", "Department")
                        .WithMany("DepartmentFacilities")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("StaffMS.Core.HospitalRelatedEntities.DepartmentPhoneNumberEntity", b =>
                {
                    b.HasOne("StaffMS.Core.DepartmentEntity", "Department")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("StaffMS.Core.HospitalRelatedEntities.DepartmentServiceEntity", b =>
                {
                    b.HasOne("StaffMS.Core.DepartmentEntity", "Department")
                        .WithMany("DepartmentServices")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("StaffMS.Core.LicenseEntity", b =>
                {
                    b.HasOne("StaffMS.Core.StaffMemberEntity", "StaffMember")
                        .WithMany("Licenses")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("StaffMS.Core.PractiseEntity", b =>
                {
                    b.HasOne("StaffMS.Core.StaffMemberEntity", "StaffMember")
                        .WithMany("Practises")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("StaffMS.Core.ServiceProvidedEntity", b =>
                {
                    b.HasOne("StaffMS.Core.StaffMemberEntity", "StaffMember")
                        .WithMany("ServicesProvided")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("StaffMS.Core.Specialisations", b =>
                {
                    b.HasOne("StaffMS.Core.StaffMemberEntity", "StaffMember")
                        .WithMany("Specialisations")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("StaffMS.Core.StaffAdminEntity", b =>
                {
                    b.HasOne("StaffMS.Core.DepartmentEntity", "Department")
                        .WithOne("StaffAdmin")
                        .HasForeignKey("StaffMS.Core.StaffAdminEntity", "StaffAdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("StaffMS.Core.StaffMemberEntity", b =>
                {
                    b.HasOne("StaffMS.Core.DepartmentEntity", "Department")
                        .WithMany("Staffmembers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("StaffMS.Core.StaffPhoneNumberEntity", b =>
                {
                    b.HasOne("StaffMS.Core.StaffMemberEntity", "StaffMember")
                        .WithMany()
                        .HasForeignKey("StaffMemberStaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("StaffMS.Core.StaffWorkinghoursEntity", b =>
                {
                    b.HasOne("StaffMS.Core.StaffMemberEntity", "StaffMember")
                        .WithMany("WorkingHours")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("StaffMS.Core.DepartmentEntity", b =>
                {
                    b.Navigation("DepartmentFacilities");

                    b.Navigation("DepartmentServices");

                    b.Navigation("PhoneNumbers");

                    b.Navigation("StaffAdmin")
                        .IsRequired();

                    b.Navigation("Staffmembers");
                });

            modelBuilder.Entity("StaffMS.Core.StaffMemberEntity", b =>
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