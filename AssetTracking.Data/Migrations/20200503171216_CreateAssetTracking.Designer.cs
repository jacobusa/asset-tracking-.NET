﻿// <auto-generated />
using AssetTracking.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssetTracking.Data.Migrations
{
    [DbContext(typeof(AssetContext))]
    [Migration("20200503171216_CreateAssetTracking")]
    partial class CreateAssetTracking
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AssetTracking.Domain.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssetTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TagNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssetTypeId");

                    b.ToTable("Asset");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssetTypeId = 1,
                            Description = "A fine laptop",
                            Manufacturer = "Dell",
                            Model = "Dell XPS 13",
                            SerialNumber = "ERT456SDF",
                            TagNumber = "JU45VD"
                        },
                        new
                        {
                            Id = 2,
                            AssetTypeId = 1,
                            Description = "A finer laptop",
                            Manufacturer = "HP",
                            Model = "Surface Studio 2",
                            SerialNumber = "MNB678ERT",
                            TagNumber = "JI78RD"
                        },
                        new
                        {
                            Id = 3,
                            AssetTypeId = 1,
                            Description = "The finest laptop",
                            Manufacturer = "Acer",
                            Model = "Swift 3",
                            SerialNumber = "JRH765RGO",
                            TagNumber = "BN67FT"
                        },
                        new
                        {
                            Id = 4,
                            AssetTypeId = 2,
                            Description = "A fine monitor",
                            Manufacturer = "Acer",
                            Model = "K2",
                            SerialNumber = "IUY234SDF",
                            TagNumber = "KJ98TY"
                        },
                        new
                        {
                            Id = 5,
                            AssetTypeId = 2,
                            Description = "A finer monitor",
                            Manufacturer = "LG",
                            Model = "UltraWide® WQHD Nano IPS Monitor with Thunderbolt™ 3",
                            SerialNumber = "JSE678DVH",
                            TagNumber = "JI65ER"
                        },
                        new
                        {
                            Id = 6,
                            AssetTypeId = 2,
                            Description = "The finest monitor",
                            Manufacturer = "HP",
                            Model = "E344c 34-inch Curved Monitor",
                            SerialNumber = "JEI876RHY",
                            TagNumber = "CD89WQ"
                        },
                        new
                        {
                            Id = 7,
                            AssetTypeId = 3,
                            Description = "A fully refurbished used phone",
                            Manufacturer = "Avaya",
                            Model = "Avaya 1408",
                            SerialNumber = "KJH678UYT",
                            TagNumber = "IJ87ER"
                        },
                        new
                        {
                            Id = 8,
                            AssetTypeId = 3,
                            Description = "A modern, four-line, basic IP desk phone",
                            Manufacturer = "Polycom",
                            Model = "Polycom 250 Ip Phone",
                            SerialNumber = "NSH876ERT",
                            TagNumber = "ML82WE"
                        },
                        new
                        {
                            Id = 9,
                            AssetTypeId = 3,
                            Description = "Three-way Calling (Conference)On-hook DialingCall",
                            Manufacturer = "Cisco",
                            Model = "Cisco SPA 303 IP Phone",
                            SerialNumber = "HUE876ERT",
                            TagNumber = "IJ27RD"
                        });
                });

            modelBuilder.Entity("AssetTracking.Domain.AssetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AssetType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Computer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Monitor"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Phone"
                        });
                });

            modelBuilder.Entity("AssetTracking.Domain.Asset", b =>
                {
                    b.HasOne("AssetTracking.Domain.AssetType", "AssetType")
                        .WithMany("Assets")
                        .HasForeignKey("AssetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
