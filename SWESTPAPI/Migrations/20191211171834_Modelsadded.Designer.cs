﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SWESTPAPI.Data;

namespace SWESTPAPI.Migrations
{
    [DbContext(typeof(SWESTPDBContext))]
    [Migration("20191211171834_Modelsadded")]
    partial class Modelsadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SWESTPAPI.Models.AppUser", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ID")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Role");

                    b.Property<string>("VCode");

                    b.Property<string>("isVerified");

                    b.HasKey("Email");

                    b.ToTable("appUsers");
                });

            modelBuilder.Entity("SWESTPAPI.Models.ClassRoutine", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseCode");

                    b.Property<string>("Day");

                    b.Property<string>("RoomNo");

                    b.Property<string>("Section");

                    b.Property<int>("SlotID");

                    b.Property<string>("TeacherInitial");

                    b.HasKey("id");

                    b.HasIndex("CourseCode");

                    b.HasIndex("SlotID");

                    b.ToTable("classRoutines");
                });

            modelBuilder.Entity("SWESTPAPI.Models.Course", b =>
                {
                    b.Property<string>("CourseCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("CourseCode");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("SWESTPAPI.Models.CourseOffer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseCode");

                    b.Property<int?>("ExamRoutineid");

                    b.Property<int>("semester");

                    b.HasKey("id");

                    b.HasIndex("CourseCode")
                        .IsUnique()
                        .HasFilter("[CourseCode] IS NOT NULL");

                    b.HasIndex("ExamRoutineid");

                    b.ToTable("courseOffers");
                });

            modelBuilder.Entity("SWESTPAPI.Models.ExamRoutine", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseCode");

                    b.Property<DateTime>("Date");

                    b.Property<int>("SlotID");

                    b.HasKey("id");

                    b.HasIndex("CourseCode");

                    b.HasIndex("SlotID");

                    b.ToTable("examRoutines");
                });

            modelBuilder.Entity("SWESTPAPI.Models.MyTask", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Details")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<DateTime>("Time");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("id");

                    b.HasIndex("Email");

                    b.ToTable("myTasks");
                });

            modelBuilder.Entity("SWESTPAPI.Models.Profile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("Section");

                    b.Property<int>("Semester");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("SWESTPAPI.Models.Slot", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("id");

                    b.ToTable("slots");
                });

            modelBuilder.Entity("SWESTPAPI.Models.SweEvent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AttachmentUrl");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Details");

                    b.Property<DateTime>("Time");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("sweEvents");
                });

            modelBuilder.Entity("SWESTPAPI.Models.UserCourse", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseCode");

                    b.Property<string>("Email");

                    b.Property<string>("Section");

                    b.HasKey("id");

                    b.HasIndex("CourseCode");

                    b.HasIndex("Email");

                    b.ToTable("userCourses");
                });

            modelBuilder.Entity("SWESTPAPI.Models.ClassRoutine", b =>
                {
                    b.HasOne("SWESTPAPI.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseCode");

                    b.HasOne("SWESTPAPI.Models.Slot", "Slot")
                        .WithMany("classRoutines")
                        .HasForeignKey("SlotID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SWESTPAPI.Models.CourseOffer", b =>
                {
                    b.HasOne("SWESTPAPI.Models.Course", "Course")
                        .WithOne("CourseOffer")
                        .HasForeignKey("SWESTPAPI.Models.CourseOffer", "CourseCode");

                    b.HasOne("SWESTPAPI.Models.ExamRoutine", "ExamRoutine")
                        .WithMany()
                        .HasForeignKey("ExamRoutineid");
                });

            modelBuilder.Entity("SWESTPAPI.Models.ExamRoutine", b =>
                {
                    b.HasOne("SWESTPAPI.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseCode");

                    b.HasOne("SWESTPAPI.Models.Slot", "Slot")
                        .WithMany("examRoutines")
                        .HasForeignKey("SlotID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SWESTPAPI.Models.MyTask", b =>
                {
                    b.HasOne("SWESTPAPI.Models.AppUser", "AppUser")
                        .WithMany("myTasks")
                        .HasForeignKey("Email");
                });

            modelBuilder.Entity("SWESTPAPI.Models.Profile", b =>
                {
                    b.HasOne("SWESTPAPI.Models.AppUser", "AppUser")
                        .WithOne("Profile")
                        .HasForeignKey("SWESTPAPI.Models.Profile", "Email");
                });

            modelBuilder.Entity("SWESTPAPI.Models.UserCourse", b =>
                {
                    b.HasOne("SWESTPAPI.Models.Course", "Course")
                        .WithMany("userCourses")
                        .HasForeignKey("CourseCode");

                    b.HasOne("SWESTPAPI.Models.AppUser", "AppUser")
                        .WithMany("userCourses")
                        .HasForeignKey("Email");
                });
#pragma warning restore 612, 618
        }
    }
}
