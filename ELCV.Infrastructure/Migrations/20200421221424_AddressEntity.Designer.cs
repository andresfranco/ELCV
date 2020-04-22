﻿// <auto-generated />
using ELCV.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ELCV.Infrastructure.Migrations
{
    [DbContext(typeof(ELCVContext))]
    [Migration("20200421221424_AddressEntity")]
    partial class AddressEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ELCV.Core.Entities.City", b =>
                {
                    b.Property<string>("CityCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateCode1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CityCode");

                    b.HasIndex("CountryCode1");

                    b.HasIndex("StateCode1");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ELCV.Core.Entities.Country", b =>
                {
                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryCode");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("ELCV.Core.Entities.State", b =>
                {
                    b.Property<string>("StateCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateCode");

                    b.HasIndex("CountryCode1");

                    b.ToTable("States");
                });

            modelBuilder.Entity("ELCV.Core.Entities.City", b =>
                {
                    b.HasOne("ELCV.Core.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryCode1");

                    b.HasOne("ELCV.Core.Entities.State", "State")
                        .WithMany()
                        .HasForeignKey("StateCode1");
                });

            modelBuilder.Entity("ELCV.Core.Entities.State", b =>
                {
                    b.HasOne("ELCV.Core.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryCode1");
                });
#pragma warning restore 612, 618
        }
    }
}
