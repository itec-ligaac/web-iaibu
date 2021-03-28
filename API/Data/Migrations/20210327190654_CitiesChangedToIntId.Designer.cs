﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210327190654_CitiesChangedToIntId")]
    partial class CitiesChangedToIntId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("API.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<int>("Geonameid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubCountry")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("API.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("IsoCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("API.Entities.CountryData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DailyVaccinations")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DailyVaccinationsPerHundred")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DailyVaccinationsPerMilion")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DailyVaccinationsRaw")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("PeopleFullyVaccinated")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("PeopleFullyVaccinatedPerHundred")
                        .HasColumnType("TEXT");

                    b.Property<int>("PeopleVaccinated")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("PeopleVaccinatedPerHunderd")
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalVaccinations")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalVaccinationsPerHunderd")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("CountryData");
                });

            modelBuilder.Entity("API.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("API.Entities.CountryData", b =>
                {
                    b.HasOne("API.Entities.Country", null)
                        .WithMany("Data")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("API.Entities.Country", b =>
                {
                    b.Navigation("Data");
                });
#pragma warning restore 612, 618
        }
    }
}
