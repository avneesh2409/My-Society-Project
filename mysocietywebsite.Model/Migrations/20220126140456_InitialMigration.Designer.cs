﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mysocietywebsite.Model.ApplicationDbContext;

namespace mysocietywebsite.Model.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220126140456_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("mysocietywebsite.Model.Entities.Gallery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Gallery");
                });

            modelBuilder.Entity("mysocietywebsite.Model.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("372e9e7e-1181-464e-8721-57aae55723d6"),
                            CreatedBy = new Guid("372e9e7e-1181-464e-8721-57aae55723d6"),
                            CreatedOn = new DateTime(2022, 1, 26, 14, 4, 55, 767, DateTimeKind.Utc).AddTicks(9690),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedBy = new Guid("372e9e7e-1181-464e-8721-57aae55723d6"),
                            ModifiedOn = new DateTime(2022, 1, 26, 14, 4, 55, 768, DateTimeKind.Utc).AddTicks(222),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("4c034a10-98b9-4f8f-ae0d-e7da889b888c"),
                            CreatedBy = new Guid("372e9e7e-1181-464e-8721-57aae55723d6"),
                            CreatedOn = new DateTime(2022, 1, 26, 14, 4, 55, 768, DateTimeKind.Utc).AddTicks(538),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedBy = new Guid("372e9e7e-1181-464e-8721-57aae55723d6"),
                            ModifiedOn = new DateTime(2022, 1, 26, 14, 4, 55, 768, DateTimeKind.Utc).AddTicks(563),
                            Name = "User"
                        });
                });

            modelBuilder.Entity("mysocietywebsite.Model.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Contact")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Fullname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d98e6c37-3bc4-4874-b71e-e500a44ab56e"),
                            Address = "H.No - 30 Indus Town",
                            Contact = "9109072549",
                            CreatedBy = new Guid("d98e6c37-3bc4-4874-b71e-e500a44ab56e"),
                            CreatedOn = new DateTime(2022, 1, 26, 14, 4, 55, 785, DateTimeKind.Utc).AddTicks(459),
                            Email = "tarun@gmail.com",
                            Fullname = "Tarunendra",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedBy = new Guid("d98e6c37-3bc4-4874-b71e-e500a44ab56e"),
                            ModifiedOn = new DateTime(2022, 1, 26, 14, 4, 55, 785, DateTimeKind.Utc).AddTicks(526),
                            Password = "BJJcVkTHd9Qkv8iCM8srzsyU50CjkRe4ckHbWkHVlAc=",
                            RoleId = new Guid("372e9e7e-1181-464e-8721-57aae55723d6"),
                            Username = "AD"
                        });
                });

            modelBuilder.Entity("mysocietywebsite.Model.Entities.Gallery", b =>
                {
                    b.HasOne("mysocietywebsite.Model.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("mysocietywebsite.Model.Entities.User", b =>
                {
                    b.HasOne("mysocietywebsite.Model.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}