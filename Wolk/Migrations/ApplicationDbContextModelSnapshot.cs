﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wolk.ApplicatonDbContext;

#nullable disable

namespace Wolk.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Wolk.Entites.Audience", b =>
                {
                    b.Property<Guid>("AudienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberAudience")
                        .HasColumnType("int");

                    b.HasKey("AudienceId");

                    b.ToTable("Audiences");
                });

            modelBuilder.Entity("Wolk.Entites.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Wolk.Entites.Schedule", b =>
                {
                    b.Property<Guid>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AudienceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberLesson")
                        .HasColumnType("int");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ScheduleId");

                    b.HasIndex("AudienceId")
                        .IsUnique();

                    b.HasIndex("SubjectId")
                        .IsUnique();

                    b.HasIndex("TeacherId")
                        .IsUnique();

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Wolk.Entites.Subject", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameSubject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Wolk.Entites.Teacher", b =>
                {
                    b.Property<Guid>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Wolk.Entites.Group", b =>
                {
                    b.HasOne("Wolk.Entites.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Wolk.Entites.Schedule", b =>
                {
                    b.HasOne("Wolk.Entites.Audience", "Audience")
                        .WithOne("Schedule")
                        .HasForeignKey("Wolk.Entites.Schedule", "AudienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wolk.Entites.Subject", "Subject")
                        .WithOne("Schedule")
                        .HasForeignKey("Wolk.Entites.Schedule", "SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wolk.Entites.Teacher", "Teacher")
                        .WithOne("Schedule")
                        .HasForeignKey("Wolk.Entites.Schedule", "TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Audience");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Wolk.Entites.Audience", b =>
                {
                    b.Navigation("Schedule")
                        .IsRequired();
                });

            modelBuilder.Entity("Wolk.Entites.Subject", b =>
                {
                    b.Navigation("Schedule")
                        .IsRequired();
                });

            modelBuilder.Entity("Wolk.Entites.Teacher", b =>
                {
                    b.Navigation("Schedule")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
