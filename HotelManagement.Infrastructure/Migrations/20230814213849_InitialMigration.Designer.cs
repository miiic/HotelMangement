﻿// <auto-generated />
using System;
using HotelManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelManagement.Infrastructure.Migrations
{
    [DbContext(typeof(HotelManagementDbContext))]
    [Migration("20230814213849_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HotelManagement.Domain.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Departure")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("HotelManagement.Domain.Entities.Hotel", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("HotelManagement.Domain.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("HotelName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("HotelName");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelManagement.Domain.Entities.Booking", b =>
                {
                    b.HasOne("HotelManagement.Domain.Entities.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelManagement.Domain.Entities.Room", b =>
                {
                    b.HasOne("HotelManagement.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelName");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelManagement.Domain.Entities.Hotel", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelManagement.Domain.Entities.Room", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
