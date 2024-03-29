﻿// <auto-generated />
using System;
using GraphQL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApp.GraphQL.Migrations
{
    [DbContext(typeof(DeviceDBContext))]
    partial class DeviceDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GraphQL.Database.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeviceName");

                    b.Property<int?>("DeviceTypeId");

                    b.Property<int>("MyProperty");

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.HasIndex("DeviceTypeId");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("GraphQL.Database.Models.DeviceType", b =>
                {
                    b.Property<int>("DeviceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeviceTypeName");

                    b.Property<int>("UniqueId");

                    b.HasKey("DeviceTypeId");

                    b.ToTable("DeviceType");
                });

            modelBuilder.Entity("GraphQL.Database.Models.Device", b =>
                {
                    b.HasOne("GraphQL.Database.Models.DeviceType", "DeviceType")
                        .WithMany("Device")
                        .HasForeignKey("DeviceTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
