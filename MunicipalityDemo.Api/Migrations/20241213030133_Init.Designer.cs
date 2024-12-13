﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MunicipalityDemo.Api.Data;

#nullable disable

namespace MunicipalityDemo.Api.Migrations
{
    [DbContext(typeof(MunicipalityContext))]
    [Migration("20241213030133_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("MunicipalityDemo.Api.Entities.Municipality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Mayor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Party")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Population")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Municipalities");

                    b.HasData(
                        new
                        {
                            Id = 45014,
                            Mayor = "Rodrigo Moreno Contreras",
                            Party = "Partido Socialista Obrero Español (PSOE)",
                            Population = 5209
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
