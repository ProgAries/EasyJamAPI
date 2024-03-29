﻿// <auto-generated />
using System;
using EasyJamDAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyJamDAL.Migrations
{
    [DbContext(typeof(EasyJamContext))]
    [Migration("20231220132628_ChordProgressionAdded")]
    partial class ChordProgressionAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EasyJamDAL.Entities.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("EncodedPassword")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Salt")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4253a3ec-d1cf-4807-bd6a-af564b01c17e"),
                            Email = "Test@test.com",
                            EncodedPassword = new byte[] { 178, 9, 240, 198, 219, 186, 132, 253, 20, 159, 108, 197, 225, 33, 197, 210, 105, 231, 218, 35, 192, 197, 25, 86, 211, 45, 155, 29, 53, 37, 62, 159, 46, 225, 128, 140, 166, 116, 146, 133, 142, 18, 51, 1, 252, 106, 78, 194, 86, 94, 121, 233, 41, 102, 103, 2, 94, 85, 203, 125, 218, 71, 228, 118 },
                            FirstName = "Rocco",
                            LastName = "Pasanisi",
                            Salt = new Guid("3757f170-f7d6-4f9a-8a4d-064fcea84a66")
                        });
                });

            modelBuilder.Entity("EasyJamDAL.Entities.ChordProgression", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Chord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Chords");
                });

            modelBuilder.Entity("EasyJamDAL.Entities.JamSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Drum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gtr1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gtr2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRandom")
                        .HasColumnType("bit");

                    b.Property<string>("Keys")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mic1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mic2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Other1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Other2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Other3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Jams");
                });

            modelBuilder.Entity("EasyJamDAL.Entities.Musicien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Instrument1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instrument2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instrument3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Musiciens");
                });
#pragma warning restore 612, 618
        }
    }
}
