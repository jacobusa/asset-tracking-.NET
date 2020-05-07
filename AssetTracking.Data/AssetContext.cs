using AssetTracking.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace AssetTracking.Data
{
    public class AssetContext : DbContext
    {
        public AssetContext() : base() { }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Change the connection string here for your home computer/lab computer
            optionsBuilder.UseSqlServer(@"Server=SAIT221781\SQLEXPRESS01;
                                          Database=AssetTracking;
                                          Trusted_Connection=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seed data created here
            modelBuilder.Entity<AssetType>().HasData(
            new AssetType { Id = 1, Name = "Computer" },
            new AssetType { Id = 2, Name = "Monitor" },
            new AssetType { Id = 3, Name = "Phone" }
            );
            modelBuilder.Entity<Asset>().HasData(
            new Asset
            {
                Id = 1,
                TagNumber = "JU45VD",
                AssetTypeId = 1,
                //AssetType = new AssetType { Id = 1, Name = "Computer" },
                Manufacturer = "Dell",
                Model = "Dell XPS 13",
                Description = "A fine laptop",
                SerialNumber = "ERT456SDF"

            },
            new Asset
            {
                Id = 2,
                TagNumber = "JI78RD",
                AssetTypeId = 1,
                //AssetType = new AssetType { Id = 1, Name = "Computer" },
                Manufacturer = "HP",
                Model = "Surface Studio 2",
                Description = "A finer laptop",
                SerialNumber = "MNB678ERT"

            },
            new Asset
            {
                Id = 3,
                TagNumber = "BN67FT",
                AssetTypeId = 1,
                //AssetType = new AssetType { Id = 1, Name = "Computer" },
                Manufacturer = "Acer",
                Model = "Swift 3",
                Description = "The finest laptop",
                SerialNumber = "JRH765RGO"

            },
            new Asset
            {
                Id = 4,
                TagNumber = "KJ98TY",
                AssetTypeId = 2,
                //AssetType = new AssetType { Id = 2, Name = "Monitor" },
                Manufacturer = "Acer",
                Model = "K2",
                Description = "A fine monitor",
                SerialNumber = "IUY234SDF"

            },
            new Asset
            {
                Id = 5,
                TagNumber = "JI65ER",
                AssetTypeId = 2,
                //AssetType = new AssetType { Id = 2, Name = "Monitor" },
                Manufacturer = "LG",
                Model = "UltraWide® WQHD Nano IPS Monitor with Thunderbolt™ 3",
                Description = "A finer monitor",
                SerialNumber = "JSE678DVH"

            },
            new Asset
            {
                Id = 6,
                TagNumber = "CD89WQ",
                AssetTypeId = 2,
                //AssetType = new AssetType { Id = 2, Name = "Monitor" },
                Manufacturer = "HP",
                Model = "E344c 34-inch Curved Monitor",
                Description = "The finest monitor",
                SerialNumber = "JEI876RHY"

            },
            new Asset
            {
                Id = 7,
                TagNumber = "IJ87ER",
                AssetTypeId = 3,
                //AssetType = new AssetType { Id = 3, Name = "Phone" },
                Manufacturer = "Avaya",
                Model = "Avaya 1408",
                Description = "A fully refurbished used phone",
                SerialNumber = "KJH678UYT"

            },
            new Asset
            {
                Id = 8,
                TagNumber = "ML82WE",
                AssetTypeId = 3,
                //AssetType = new AssetType { Id = 3, Name = "Phone" },
                Manufacturer = "Polycom",
                Model = "Polycom 250 Ip Phone",
                Description = "A modern, four-line, basic IP desk phone",
                SerialNumber = "NSH876ERT"

            },
            new Asset
            {
                Id = 9,
                TagNumber = "IJ27RD",
                AssetTypeId = 3,
                //AssetType = new AssetType { Id = 3, Name = "Phone" },
                Manufacturer = "Cisco",
                Model = "Cisco SPA 303 IP Phone",
                Description = "Three-way Calling (Conference)On-hook DialingCall",
                SerialNumber = "HUE876ERT"

            }
            );
        }
    }
}
