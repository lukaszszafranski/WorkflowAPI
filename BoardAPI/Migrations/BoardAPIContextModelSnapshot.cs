﻿// <auto-generated />
using System;
using BoardAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BoardAPI.Migrations
{
    [DbContext(typeof(WorkflowAPIContext))]
    partial class BoardAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("ProjectID");

                    b.HasKey("ColumnID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Column");
                });

            modelBuilder.Entity("BoardAPI.Models.ProjectsModels.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<int>("OrganizationID");

                    b.Property<string>("Status");

                    b.Property<string>("Title");

                    b.Property<string>("VisibilityState");

                    b.HasKey("ProjectID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("BoardAPI.Models.ProjectsModels.Tag", b =>
                {
                    b.Property<int>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProjectID");

                    b.Property<string>("TagDescription");

                    b.Property<string>("TagName");

                    b.HasKey("TagID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("BoardAPI.Models.ProjectsModels.WorkItem", b =>
                {
                    b.Property<int>("WorkItemID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("ProjectID");

                    b.HasKey("WorkItemID");

                    b.HasIndex("ProjectID");

                    b.ToTable("WorkItem");
                });

            modelBuilder.Entity("BoardAPI.Models.UserModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("OrganizationID");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<int?>("ProjectID");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BoardAPI.Models.ProjectsModels.Column", b =>
                {
                    b.HasOne("BoardAPI.Models.ProjectsModels.Project")
                        .WithMany("Columns")
                        .HasForeignKey("ProjectID");
                });

            modelBuilder.Entity("BoardAPI.Models.ProjectsModels.Project", b =>
                {
                    b.HasOne("BoardAPI.Models.OrganizationsModels.Organization", "Organization")
                        .WithMany("ProjectsList")
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BoardAPI.Models.ProjectsModels.Tag", b =>
                {
                    b.HasOne("BoardAPI.Models.ProjectsModels.Project")
                        .WithMany("Tags")
                        .HasForeignKey("ProjectID");
                });

            modelBuilder.Entity("BoardAPI.Models.ProjectsModels.WorkItem", b =>
                {
                    b.HasOne("BoardAPI.Models.ProjectsModels.Project")
                        .WithMany("WorkItems")
                        .HasForeignKey("ProjectID");
                });

            modelBuilder.Entity("BoardAPI.Models.UserModels.User", b =>
                {
                    b.HasOne("BoardAPI.Models.OrganizationsModels.Organization", "Organization")
                        .WithMany("Members")
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BoardAPI.Models.ProjectsModels.Project")
                        .WithMany("Members")
                        .HasForeignKey("ProjectID");
                });
#pragma warning restore 612, 618
        }
    }
}
