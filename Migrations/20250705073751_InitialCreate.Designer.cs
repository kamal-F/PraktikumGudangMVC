﻿// <auto-generated />
using GudangWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GudangWebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250705073751_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.6");

            modelBuilder.Entity("GudangWebApp.Models.Barang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("JumlahStok")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kategori")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KodeBarang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NamaBarang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Barang");
                });
#pragma warning restore 612, 618
        }
    }
}
