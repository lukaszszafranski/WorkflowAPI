﻿// <auto-generated />
using System;
using BoardAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WorkflowAPI.Migrations
{
    [DbContext(typeof(WorkflowAPIContext))]
    [Migration("20230110183848_AddRoleAndTimesheetModels")]
    partial class AddRoleAndTimesheetModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BoardAPI.Models.OrganizationsModels.Organization", b =>
                {
                    b.Property<int>("OrganizationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrganizationName");

                    b.HasKey("OrganizationID");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("BoardAPI.Models.ProjectsModels.Column", b =>
                {
                    b.Property<int>("ColumnID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColumnName");

                    b.Property<int>("ProjectID");

                    b.HasKey("ColumnID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Column");
                });

            modelBuilder.Entity("BoardAPI.Models.ProjectsModels.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("ProjectID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("BoardAPI.Models.ProjectsModels.Task", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColumnID");

                    b.Property<string>("Name");

                    b.HasKey("TaskID");

                    b.HasIndex("ColumnID");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("BoardAPI.Models.ProjectsModels.Timesheet", b =>
                {
                    b.Property<int>("TimesheetID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("FromDate");

                    b.Property<int>("ProjectID");

                    b.Property<int>("TimeRegistrated");

                    b.Property<string>("TimesheetStatus");

                    b.Property<DateTime>("ToDate");

                    b.Property<int>("UserId");

                    b.HasKey("TimesheetID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("UserId");

                    b.ToTable("Timesheet");
                });

            modelBuilder.Entity("BoardAPI.Models.ProjectsModels.TimesheetDetails", b =>
                {
                    b.Property<int>("TimesheetDetailsID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Day");

                    b.Property<int>("Month");

                    b.Property<int>("RegisteredHours");

                    b.Property<int>("TimesheetID");

                    b.Property<int>("Year");

                    b.HasKey("TimesheetDetailsID");

                    b.HasIndex("TimesheetID");

                    b.ToTable("TimesheetDetails");
                });

            modelBuilder.Entity("BoardAPI.Models.UserModels.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Role");
                });

            modelBuilder.Entity("BoardAPI.Models.UserModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BoardAPI.Models.ProjectsModels.Column", b =>
                {
                    b.HasOne("BoardAPI.Models.ProjectsModels.Project", "Project")
                        .WithMany("Columns")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BoardAPI.Models.ProjectsModels.Task", b =>
                {
                    b.HasOne("BoardAPI.Models.ProjectsModels.Column", "Column")
                        .WithMany("Tasks")
                        .HasForeignKey("ColumnID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BoardAPI.Models.ProjectsModels.Timesheet", b =>
                {
                    b.HasOne("BoardAPI.Models.ProjectsModels.Project", "Project")
                        .WithMany("Timesheets")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BoardAPI.Models.UserModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BoardAPI.Models.ProjectsModels.TimesheetDetails", b =>
                {
                    b.HasOne("BoardAPI.Models.ProjectsModels.Timesheet", "Timesheet")
                        .WithMany("TimesheetDetails")
                        .HasForeignKey("TimesheetID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BoardAPI.Models.UserModels.Role", b =>
                {
                    b.HasOne("BoardAPI.Models.UserModels.User", "User")
                        .WithOne("Role")
                        .HasForeignKey("BoardAPI.Models.UserModels.Role", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}