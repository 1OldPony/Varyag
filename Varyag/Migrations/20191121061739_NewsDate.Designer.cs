﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Varyag.Models;

namespace Varyag.Migrations
{
    [DbContext(typeof(VaryagContext))]
    [Migration("20191121061739_NewsDate")]
    partial class NewsDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("Varyag.Models.Foto", b =>
                {
                    b.Property<int>("FotoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alt");

                    b.Property<string>("Name");

                    b.Property<int?>("NewsID");

                    b.Property<byte[]>("ProjectFoto")
                        .IsRequired();

                    b.Property<int?>("ShipProjectID");

                    b.HasKey("FotoID");

                    b.HasIndex("NewsID");

                    b.HasIndex("ShipProjectID");

                    b.ToTable("Foto");
                });

            modelBuilder.Entity("Varyag.Models.News", b =>
                {
                    b.Property<int>("NewsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Header");

                    b.Property<int>("KeyWord");

                    b.Property<string>("MainStory");

                    b.Property<string>("MiddleImgAlt");

                    b.Property<string>("MiddleImgPath");

                    b.Property<string>("MiddleImgScale");

                    b.Property<string>("MiddleImgTitle");

                    b.Property<string>("MiddleImgX");

                    b.Property<string>("MiddleImgY");

                    b.Property<string>("MiddleStory");

                    b.Property<string>("NewsDate");

                    b.Property<string>("ShortImgAlt");

                    b.Property<string>("ShortImgPath");

                    b.Property<string>("ShortImgScale");

                    b.Property<string>("ShortImgTitle");

                    b.Property<string>("ShortImgX");

                    b.Property<string>("ShortImgY");

                    b.Property<string>("ShortStory");

                    b.Property<string>("WideImgAlt");

                    b.Property<string>("WideImgPath");

                    b.Property<string>("WideImgScale");

                    b.Property<string>("WideImgTitle");

                    b.Property<string>("WideImgX");

                    b.Property<string>("WideImgY");

                    b.Property<string>("WideStory");

                    b.HasKey("NewsId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("Varyag.Models.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BoatRow");

                    b.Property<bool>("BoatSail");

                    b.Property<bool>("BoatTraditional");

                    b.Property<bool>("BoatYal");

                    b.Property<bool>("Botik");

                    b.Property<string>("Deep")
                        .HasMaxLength(5);

                    b.Property<string>("Description");

                    b.Property<int?>("EnginePower");

                    b.Property<int?>("FreshWaterCap");

                    b.Property<int?>("FuelCap");

                    b.Property<bool>("KaterCabin");

                    b.Property<bool>("KaterFish");

                    b.Property<bool>("KaterPass");

                    b.Property<bool>("KaterProject");

                    b.Property<bool>("KaterRow");

                    b.Property<bool>("LadyaProject");

                    b.Property<bool>("LadyaRow");

                    b.Property<bool>("LadyaSail");

                    b.Property<string>("Length")
                        .HasMaxLength(5);

                    b.Property<byte[]>("MainFoto");

                    b.Property<bool>("MaketCinema");

                    b.Property<bool>("MaketDesign");

                    b.Property<bool>("MaketMuseum");

                    b.Property<bool>("MaketStudy");

                    b.Property<string>("Mass")
                        .HasMaxLength(10);

                    b.Property<bool>("Motosailer");

                    b.Property<string>("Name");

                    b.Property<string>("NumberOfOars")
                        .HasMaxLength(5);

                    b.Property<int?>("PassengerCap");

                    b.Property<string>("Price");

                    b.Property<string>("SailArea")
                        .HasMaxLength(10);

                    b.Property<bool>("SailboatHistorical");

                    b.Property<bool>("SailboatProject");

                    b.Property<bool>("SailboatStudy");

                    b.Property<byte[]>("ShipSheme");

                    b.Property<byte[]>("ShipShemeFull");

                    b.Property<bool>("Shvertbot");

                    b.Property<int?>("SleepingAreas");

                    b.Property<int?>("Speed");

                    b.Property<string>("Volume")
                        .HasMaxLength(10);

                    b.Property<string>("Windth")
                        .HasMaxLength(5);

                    b.Property<bool>("Yacht");

                    b.HasKey("ProjectID");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Varyag.Models.User", b =>
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
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
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
                    b.HasOne("Varyag.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Varyag.Models.User")
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

                    b.HasOne("Varyag.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Varyag.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Varyag.Models.Foto", b =>
                {
                    b.HasOne("Varyag.Models.News", "News")
                        .WithMany("NewsFotos")
                        .HasForeignKey("NewsID");

                    b.HasOne("Varyag.Models.Project", "ShipProject")
                        .WithMany("ShipFotos")
                        .HasForeignKey("ShipProjectID");
                });
#pragma warning restore 612, 618
        }
    }
}
