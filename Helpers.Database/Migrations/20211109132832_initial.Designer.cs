﻿// <auto-generated />
using System;
using Helpers.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Helpers.Database.Migrations
{
    [DbContext(typeof(DarkXmeraSecurityDbContext))]
    [Migration("20211109132832_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Models.ActionModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("StatusId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("Core.Models.ModuleModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("StatusId");

                    b.HasIndex("Url")
                        .IsUnique();

                    b.ToTable("Modules");

                    b.HasData(
                        new
                        {
                            Id = "d6c1a4a2-4f70-4ce1-9dd7-87cad50a8ea7",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Este es el modulo de seguridad",
                            Name = "Seguridad",
                            StatusId = 1,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "security"
                        });
                });

            modelBuilder.Entity("Core.Models.ModuleRoleModel", b =>
                {
                    b.Property<string>("ModuleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ModuleId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("StatusId");

                    b.ToTable("ModuleRoles");

                    b.HasData(
                        new
                        {
                            ModuleId = "d6c1a4a2-4f70-4ce1-9dd7-87cad50a8ea7",
                            RoleId = "108d0430-3a5b-423b-a23a-393d35e681f4",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id = "52bcf1ae-0335-4746-9d95-92690e25af30",
                            StatusId = 1,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Core.Models.RoleModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("StatusId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = "108d0430-3a5b-423b-a23a-393d35e681f4",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Este es el rol con todos los permisos",
                            Name = "Admin",
                            StatusId = 1,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Core.Models.RoleScreenModel", b =>
                {
                    b.Property<string>("ScreenId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ScreenId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("StatusId");

                    b.ToTable("RoleScreenModel");

                    b.HasData(
                        new
                        {
                            ScreenId = "c29c6db6-41e4-4be9-b7e9-c2432241641c",
                            RoleId = "108d0430-3a5b-423b-a23a-393d35e681f4",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id = "b06d68c5-f241-4920-9feb-6c2b76f23d15",
                            StatusId = 1,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ScreenId = "6082c3a3-be96-4f63-8c1b-24b4f8de38f0",
                            RoleId = "108d0430-3a5b-423b-a23a-393d35e681f4",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id = "1d068a28-954b-4453-93ea-54cf90059ff6",
                            StatusId = 1,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ScreenId = "8e0a4306-f3fd-43f4-8ae0-c1f68bcd2d9b",
                            RoleId = "108d0430-3a5b-423b-a23a-393d35e681f4",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id = "2db8f1ec-868c-40ca-a672-2c6462848c21",
                            StatusId = 1,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Core.Models.ScreenModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ModuleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("StatusId");

                    b.HasIndex("Url")
                        .IsUnique();

                    b.ToTable("Screens");

                    b.HasData(
                        new
                        {
                            Id = "c29c6db6-41e4-4be9-b7e9-c2432241641c",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Pantalla de configuración de roles",
                            ModuleId = "d6c1a4a2-4f70-4ce1-9dd7-87cad50a8ea7",
                            Name = "Roles",
                            StatusId = 1,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "roles"
                        },
                        new
                        {
                            Id = "6082c3a3-be96-4f63-8c1b-24b4f8de38f0",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Pantalla de configuración de modulos",
                            ModuleId = "d6c1a4a2-4f70-4ce1-9dd7-87cad50a8ea7",
                            Name = "Modules",
                            StatusId = 1,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "modules"
                        },
                        new
                        {
                            Id = "8e0a4306-f3fd-43f4-8ae0-c1f68bcd2d9b",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Pantalla de configuración de pantallas",
                            ModuleId = "d6c1a4a2-4f70-4ce1-9dd7-87cad50a8ea7",
                            Name = "Screens",
                            StatusId = 1,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "screens"
                        });
                });

            modelBuilder.Entity("Core.Models.StatusModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Active record",
                            Name = "Active"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Inactive record",
                            Name = "Inactive"
                        });
                });

            modelBuilder.Entity("Core.Models.UserModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "0dafe045-02ca-4e57-b4b8-b74bd4675dad",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin258@yopmail.com",
                            Password = "21232f297a57a5a743894a0e4a801fc3",
                            RoleId = "108d0430-3a5b-423b-a23a-393d35e681f4",
                            StatusId = 1,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Core.Models.ActionModel", b =>
                {
                    b.HasOne("Core.Models.StatusModel", "Status")
                        .WithMany("Actions")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Core.Models.ModuleModel", b =>
                {
                    b.HasOne("Core.Models.StatusModel", "Status")
                        .WithMany("Modules")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Core.Models.ModuleRoleModel", b =>
                {
                    b.HasOne("Core.Models.ModuleModel", "Module")
                        .WithMany("ModuleRoles")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.RoleModel", "Role")
                        .WithMany("ModuleRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.StatusModel", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");

                    b.Navigation("Role");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Core.Models.RoleModel", b =>
                {
                    b.HasOne("Core.Models.StatusModel", "Status")
                        .WithMany("Roles")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Core.Models.RoleScreenModel", b =>
                {
                    b.HasOne("Core.Models.RoleModel", "Role")
                        .WithMany("RoleScreens")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.ScreenModel", "Screen")
                        .WithMany("RoleScreens")
                        .HasForeignKey("ScreenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.StatusModel", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Screen");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Core.Models.ScreenModel", b =>
                {
                    b.HasOne("Core.Models.ModuleModel", "Module")
                        .WithMany("Screens")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.StatusModel", "Status")
                        .WithMany("Screens")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Core.Models.UserModel", b =>
                {
                    b.HasOne("Core.Models.RoleModel", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.StatusModel", "Status")
                        .WithMany("Users")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Core.Models.ModuleModel", b =>
                {
                    b.Navigation("ModuleRoles");

                    b.Navigation("Screens");
                });

            modelBuilder.Entity("Core.Models.RoleModel", b =>
                {
                    b.Navigation("ModuleRoles");

                    b.Navigation("RoleScreens");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Core.Models.ScreenModel", b =>
                {
                    b.Navigation("RoleScreens");
                });

            modelBuilder.Entity("Core.Models.StatusModel", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("Modules");

                    b.Navigation("Roles");

                    b.Navigation("Screens");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}