﻿// <auto-generated />
using System;
using JSE_Daily_MTM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JSEDailyMTM.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231213102359_Initialmigration")]
    partial class Initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JSE_Daily_MTM.Domain.Entities.DailyMTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CallPut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Classification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contract")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContractsTraded")
                        .HasColumnType("int");

                    b.Property<decimal?>("Delta")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DeltaValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FileDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("MTMYield")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MarkPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OpenInterest")
                        .HasColumnType("int");

                    b.Property<decimal?>("PremiumOnOption")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PreviousMTM")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PreviousPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SpotRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Strike")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Volatility")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("DailyMTM");
                });
#pragma warning restore 612, 618
        }
    }
}