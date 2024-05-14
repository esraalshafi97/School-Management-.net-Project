﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using schoolManagmentAPI.Data;

#nullable disable

namespace schoolManagmentAPI.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20240514210112_s")]
    partial class s
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("schoolManagmentAPI.Data.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassroomId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClassroomId")
                        .IsUnique();

                    b.HasIndex("TeacherId")
                        .IsUnique();

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("schoolManagmentAPI.Data.Entities.Classroom", b =>
                {
                    b.Property<int>("ClassroomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClassroomId");

                    b.ToTable("Classrooms");

                    b.HasData(
                        new
                        {
                            ClassroomId = 1,
                            Name = "Class A"
                        },
                        new
                        {
                            ClassroomId = 2,
                            Name = "Class B"
                        });
                });

            modelBuilder.Entity("schoolManagmentAPI.Data.Entities.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassroomId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassroomId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            ClassroomId = 1,
                            Name = "Alice"
                        },
                        new
                        {
                            StudentId = 2,
                            ClassroomId = 1,
                            Name = "Bob"
                        },
                        new
                        {
                            StudentId = 3,
                            ClassroomId = 2,
                            Name = "Charlie"
                        });
                });

            modelBuilder.Entity("schoolManagmentAPI.Data.Entities.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            SubjectId = 1,
                            Name = "Mathematics"
                        },
                        new
                        {
                            SubjectId = 2,
                            Name = "Science"
                        });
                });

            modelBuilder.Entity("schoolManagmentAPI.Data.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NationalNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "",
                            Name = "John Smith",
                            NationalNumber = "123456789012",
                            SubjectId = 1
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "",
                            Name = "Jane Doe",
                            NationalNumber = "987654321098",
                            SubjectId = 2
                        });
                });

            modelBuilder.Entity("schoolManagmentAPI.Data.Entities.Token", b =>
                {
                    b.Property<string>("TokenString")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TokenString");

                    b.HasIndex("UserId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("schoolManagmentAPI.Data.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 2,
                            Password = "qdeu4HhugerTB5z4oI6rIQ==",
                            UserName = "Alice"
                        });
                });

            modelBuilder.Entity("schoolManagmentAPI.Data.Entities.Appointment", b =>
                {
                    b.HasOne("schoolManagmentAPI.Data.Entities.Classroom", "Classroom")
                        .WithOne("Appointment")
                        .HasForeignKey("schoolManagmentAPI.Data.Entities.Appointment", "ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("schoolManagmentAPI.Data.Entities.Teacher", "Teacher")
                        .WithOne("Appointment")
                        .HasForeignKey("schoolManagmentAPI.Data.Entities.Appointment", "TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("schoolManagmentAPI.Data.Entities.Student", b =>
                {
                    b.HasOne("schoolManagmentAPI.Data.Entities.Classroom", "Classroom")
                        .WithMany("Students")
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");
                });

            modelBuilder.Entity("schoolManagmentAPI.Data.Entities.Teacher", b =>
                {
                    b.HasOne("schoolManagmentAPI.Data.Entities.Subject", "Subject")
                        .WithMany("Teachers")
                        .HasForeignKey("SubjectId");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("schoolManagmentAPI.Data.Entities.Token", b =>
                {
                    b.HasOne("schoolManagmentAPI.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("schoolManagmentAPI.Data.Entities.Classroom", b =>
                {
                    b.Navigation("Appointment");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("schoolManagmentAPI.Data.Entities.Subject", b =>
                {
                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("schoolManagmentAPI.Data.Entities.Teacher", b =>
                {
                    b.Navigation("Appointment");
                });
#pragma warning restore 612, 618
        }
    }
}
