﻿// <auto-generated />
using CatfishCove.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CatfishCove.Web.Migrations
{
    [DbContext(typeof(CatfishCoveDbContext))]
    [Migration("20181215020221_AddAltChickenColumn")]
    partial class AddAltChickenColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("CatfishCove.Web.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CatfishCove.Web.Models.BuffetItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("FoodTypeId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("RotationFrequency");

                    b.HasKey("Id");

                    b.HasIndex("FoodTypeId");

                    b.ToTable("BuffetItems");
                });

            modelBuilder.Entity("CatfishCove.Web.Models.BuffetItemSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BuffetItemId");

                    b.Property<int?>("FoodTypeId");

                    b.Property<int?>("NextItemId");

                    b.HasKey("Id");

                    b.HasIndex("BuffetItemId");

                    b.HasIndex("FoodTypeId");

                    b.HasIndex("NextItemId");

                    b.ToTable("BuffetSchedules");
                });

            modelBuilder.Entity("CatfishCove.Web.Models.BuffetRotatingWeek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AltChickenId");

                    b.Property<int>("BeansId");

                    b.Property<int>("CasseroleId");

                    b.Property<int>("CornId");

                    b.Property<int>("MeatId");

                    b.Property<DateTime>("SundayDate");

                    b.HasKey("Id");

                    b.HasIndex("AltChickenId");

                    b.HasIndex("BeansId");

                    b.HasIndex("CasseroleId");

                    b.HasIndex("CornId");

                    b.HasIndex("MeatId");

                    b.HasIndex("SundayDate")
                        .IsUnique();

                    b.ToTable("BuffetRotatingWeeks");
                });

            modelBuilder.Entity("CatfishCove.Web.Models.FoodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MenuOrder");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FoodTypes");
                });

            modelBuilder.Entity("CatfishCove.Web.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("FoodTypeId");

                    b.Property<string>("HalfOrderPrice");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("WholeOrderPrice")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FoodTypeId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CatfishCove.Web.Models.BuffetItem", b =>
                {
                    b.HasOne("CatfishCove.Web.Models.FoodType", "FoodType")
                        .WithMany()
                        .HasForeignKey("FoodTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CatfishCove.Web.Models.BuffetItemSchedule", b =>
                {
                    b.HasOne("CatfishCove.Web.Models.BuffetItem", "BuffetItem")
                        .WithMany()
                        .HasForeignKey("BuffetItemId");

                    b.HasOne("CatfishCove.Web.Models.FoodType", "FoodType")
                        .WithMany()
                        .HasForeignKey("FoodTypeId");

                    b.HasOne("CatfishCove.Web.Models.BuffetItemSchedule", "NextItem")
                        .WithMany()
                        .HasForeignKey("NextItemId");
                });

            modelBuilder.Entity("CatfishCove.Web.Models.BuffetRotatingWeek", b =>
                {
                    b.HasOne("CatfishCove.Web.Models.BuffetItemSchedule", "AltChicken")
                        .WithMany()
                        .HasForeignKey("AltChickenId");

                    b.HasOne("CatfishCove.Web.Models.BuffetItemSchedule", "Beans")
                        .WithMany()
                        .HasForeignKey("BeansId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CatfishCove.Web.Models.BuffetItemSchedule", "Casserole")
                        .WithMany()
                        .HasForeignKey("CasseroleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CatfishCove.Web.Models.BuffetItemSchedule", "Corn")
                        .WithMany()
                        .HasForeignKey("CornId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CatfishCove.Web.Models.BuffetItemSchedule", "Meat")
                        .WithMany()
                        .HasForeignKey("MeatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CatfishCove.Web.Models.MenuItem", b =>
                {
                    b.HasOne("CatfishCove.Web.Models.FoodType", "FoodType")
                        .WithMany()
                        .HasForeignKey("FoodTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CatfishCove.Web.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CatfishCove.Web.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CatfishCove.Web.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CatfishCove.Web.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
