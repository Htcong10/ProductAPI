﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductAPI.Data;

#nullable disable

namespace ProductAPI.Migrations
{
    [DbContext(typeof(DataDbcontext))]
    [Migration("20220824163959_AddAuth")]
    partial class AddAuth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "07860940-e6d8-41be-bd59-b31fa26c11eb",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "d8a62fce-e35e-4fdd-ac2e-38b1ef81483c",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "83b2b135-7b5d-41c6-ac0a-4412d72ee167",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "Admin",
                            ClaimValue = "Add Manager",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "Admin",
                            ClaimValue = "Edit Manager",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "Admin",
                            ClaimValue = "Delete Manager",
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            ClaimType = "Admin",
                            ClaimValue = "Get Manager",
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            ClaimType = "Admin",
                            ClaimValue = "Add Employee",
                            UserId = 1
                        },
                        new
                        {
                            Id = 6,
                            ClaimType = "Manager",
                            ClaimValue = "Edit Employee",
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            ClaimType = "Manager",
                            ClaimValue = "Delete Employee",
                            UserId = 1
                        },
                        new
                        {
                            Id = 8,
                            ClaimType = "Manager",
                            ClaimValue = "Get Employee",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProductAPI.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ProductAPI.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ProductAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4d54a8aa-00d0-457e-aa92-a3e6d0c0778d",
                            DateCreated = new DateTime(2022, 8, 24, 16, 39, 58, 917, DateTimeKind.Utc).AddTicks(293),
                            DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FullName = "Ho Trung Cong",
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAENG1dsiSw8xd63RsmZIwAMNmGZsz+tNQvLKSrnHAqiNKgFEGhbjhHk0b6aiw6sQVOA==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "htcong10@gmail.com"
                        });
                });

            modelBuilder.Entity("ProductAPI.Models.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Claimtype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("UserClaim");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimValue = "Add Manager",
                            Claimtype = "Admin",
                            CreatedDate = new DateTime(2022, 8, 24, 16, 39, 58, 916, DateTimeKind.Utc).AddTicks(8837),
                            ModifiedDate = new DateTime(2022, 8, 24, 16, 39, 58, 916, DateTimeKind.Utc).AddTicks(8839)
                        },
                        new
                        {
                            Id = 2,
                            ClaimValue = "Edit Manager",
                            Claimtype = "Admin",
                            CreatedDate = new DateTime(2022, 8, 24, 16, 39, 58, 916, DateTimeKind.Utc).AddTicks(8841),
                            ModifiedDate = new DateTime(2022, 8, 24, 16, 39, 58, 916, DateTimeKind.Utc).AddTicks(8841)
                        },
                        new
                        {
                            Id = 3,
                            ClaimValue = "Delete Manager",
                            Claimtype = "Admin",
                            CreatedDate = new DateTime(2022, 8, 24, 16, 39, 58, 916, DateTimeKind.Utc).AddTicks(8842),
                            ModifiedDate = new DateTime(2022, 8, 24, 16, 39, 58, 916, DateTimeKind.Utc).AddTicks(8843)
                        },
                        new
                        {
                            Id = 4,
                            ClaimValue = "Get Manager",
                            Claimtype = "Admin",
                            CreatedDate = new DateTime(2022, 8, 24, 16, 39, 58, 916, DateTimeKind.Utc).AddTicks(8844),
                            ModifiedDate = new DateTime(2022, 8, 24, 16, 39, 58, 916, DateTimeKind.Utc).AddTicks(8844)
                        },
                        new
                        {
                            Id = 5,
                            ClaimValue = "Add Employee",
                            Claimtype = "Manager",
                            CreatedDate = new DateTime(2022, 8, 24, 16, 39, 58, 916, DateTimeKind.Utc).AddTicks(8846),
                            ModifiedDate = new DateTime(2022, 8, 24, 16, 39, 58, 916, DateTimeKind.Utc).AddTicks(8846)
                        },
                        new
                        {
                            Id = 6,
                            ClaimValue = "Edit Employee",
                            Claimtype = "Manager",
                            CreatedDate = new DateTime(2022, 8, 24, 16, 39, 58, 916, DateTimeKind.Utc).AddTicks(8847),
                            ModifiedDate = new DateTime(2022, 8, 24, 16, 39, 58, 916, DateTimeKind.Utc).AddTicks(8848)
                        },
                        new
                        {
                            Id = 7,
                            ClaimValue = "Delete Employee",
                            Claimtype = "Manager",
                            CreatedDate = new DateTime(2022, 8, 24, 16, 39, 58, 916, DateTimeKind.Utc).AddTicks(8849),
                            ModifiedDate = new DateTime(2022, 8, 24, 16, 39, 58, 916, DateTimeKind.Utc).AddTicks(8850)
                        },
                        new
                        {
                            Id = 8,
                            ClaimValue = "Get Employee",
                            Claimtype = "Manager",
                            CreatedDate = new DateTime(2022, 8, 24, 16, 39, 58, 916, DateTimeKind.Utc).AddTicks(8852),
                            ModifiedDate = new DateTime(2022, 8, 24, 16, 39, 58, 916, DateTimeKind.Utc).AddTicks(8852)
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("ProductAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("ProductAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("ProductAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductAPI.Models.Product", b =>
                {
                    b.HasOne("ProductAPI.Models.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ProductAPI.Models.Category", b =>
                {
                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}