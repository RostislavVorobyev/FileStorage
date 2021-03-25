﻿// <auto-generated />
using System;
using LabFileStorage.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LabFileStorage.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210302112206_Task3_Seeding")]
    partial class Task3_Seeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab02FileStorageDAL.Entities.FileMetaInformation", b =>
                {
                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("DownloadsCounter")
                        .HasColumnType("bigint");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PathToFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.HasKey("FileName");

                    b.ToTable("FileMetadata");

                    b.HasData(
                        new
                        {
                            FileName = "filename",
                            CreationDate = new DateTime(2021, 3, 2, 14, 22, 6, 132, DateTimeKind.Local).AddTicks(4167),
                            DownloadsCounter = 0L,
                            Extension = ".ext",
                            PathToFile = "samplepath",
                            Size = 0L
                        });
                });
#pragma warning restore 612, 618
        }
    }
}