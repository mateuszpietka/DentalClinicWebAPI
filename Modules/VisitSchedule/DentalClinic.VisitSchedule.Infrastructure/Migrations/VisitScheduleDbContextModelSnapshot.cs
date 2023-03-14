﻿// <auto-generated />
using System;
using DentalClinic.VisitSchedule.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DentalClinic.VisitSchedule.Infrastructure.Migrations
{
    [DbContext(typeof(VisitScheduleDbContext))]
    partial class VisitScheduleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("medicalRecords")
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DentalClinic.VisitSchedule.Core.Entities.Visit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("DoctorId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsFirstVisit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<long>("PatientId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VisitTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("VisitTypeId");

                    b.ToTable("Visits", "medicalRecords");
                });

            modelBuilder.Entity("DentalClinic.VisitSchedule.Core.Entities.VisitType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VisitTypes", "medicalRecords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Control visit",
                            Hours = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Tooth root canal treatment",
                            Hours = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Prosthetics",
                            Hours = 2
                        },
                        new
                        {
                            Id = 4,
                            Description = "Putting on an orthodontic appliance",
                            Hours = 2
                        },
                        new
                        {
                            Id = 5,
                            Description = "Tooth extraction",
                            Hours = 1
                        });
                });

            modelBuilder.Entity("DentalClinic.VisitSchedule.Core.Entities.Visit", b =>
                {
                    b.HasOne("DentalClinic.VisitSchedule.Core.Entities.VisitType", "VisitType")
                        .WithMany()
                        .HasForeignKey("VisitTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VisitType");
                });
#pragma warning restore 612, 618
        }
    }
}
