﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManagement.Infra;

#nullable disable

namespace ProjectManagement.Infra.Migrations
{
    [DbContext(typeof(ProjectManagementContext))]
    [Migration("20240823032019_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ProjectManagement.Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("ProjectManagement.Domain.Entities.ProjectTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectTask");
                });

            modelBuilder.Entity("ProjectManagement.Domain.Entities.ProjectTaskHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NewValues")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OldValues")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("ProjectTaskId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectTaskId");

                    b.ToTable("ProjectTaskHistory");
                });

            modelBuilder.Entity("ProjectManagement.Domain.Entities.ProjectTask", b =>
                {
                    b.HasOne("ProjectManagement.Domain.Entities.Project", "Project")
                        .WithMany("ProjectTask")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectManagement.Domain.Entities.ProjectTaskHistory", b =>
                {
                    b.HasOne("ProjectManagement.Domain.Entities.ProjectTask", "ProjectTask")
                        .WithMany("TaskHistory")
                        .HasForeignKey("ProjectTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectTask");
                });

            modelBuilder.Entity("ProjectManagement.Domain.Entities.Project", b =>
                {
                    b.Navigation("ProjectTask");
                });

            modelBuilder.Entity("ProjectManagement.Domain.Entities.ProjectTask", b =>
                {
                    b.Navigation("TaskHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
