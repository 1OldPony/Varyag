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
    [Migration("20190401090200_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Varyag.Models.Foto", b =>
                {
                    b.Property<int>("FotoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("ProjectFoto");

                    b.Property<int>("ShipProjectID");

                    b.HasKey("FotoID");

                    b.HasIndex("ShipProjectID");

                    b.ToTable("Foto");
                });

            modelBuilder.Entity("Varyag.Models.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CruiseShip");

                    b.Property<int>("Deep");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int?>("EnginePower");

                    b.Property<bool>("FishingShip");

                    b.Property<int?>("FreshWaterCap");

                    b.Property<int?>("FuelCap");

                    b.Property<bool>("HistoricalShip");

                    b.Property<int>("Length");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("PassangerShip");

                    b.Property<int>("PassengerCap");

                    b.Property<bool>("ReserchShip");

                    b.Property<int?>("SailArea");

                    b.Property<int?>("SleepingAreas");

                    b.Property<int?>("Speed");

                    b.Property<bool>("StudyShip");

                    b.Property<int>("Type");

                    b.Property<int>("Volume");

                    b.Property<int>("Windth");

                    b.HasKey("ProjectID");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Varyag.Models.Foto", b =>
                {
                    b.HasOne("Varyag.Models.Project", "ShipProject")
                        .WithMany("Fotos")
                        .HasForeignKey("ShipProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
