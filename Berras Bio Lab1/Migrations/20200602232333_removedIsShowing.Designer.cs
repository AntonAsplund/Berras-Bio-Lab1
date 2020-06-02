﻿// <auto-generated />
using System;
using Berras_Bio_Lab1.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Berras_Bio_Lab1.Migrations
{
    [DbContext(typeof(BerrasBioDbContext))]
    [Migration("20200602232333_removedIsShowing")]
    partial class removedIsShowing
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Berras_Bio_Lab1.Models.MovieModel", b =>
                {
                    b.Property<int>("MovieModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RunTime")
                        .HasColumnType("int");

                    b.HasKey("MovieModelId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Berras_Bio_Lab1.Models.TheaterModel", b =>
                {
                    b.Property<int>("TheaterModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.HasKey("TheaterModelId");

                    b.ToTable("Theaters");
                });

            modelBuilder.Entity("Berras_Bio_Lab1.Models.TicketModel", b =>
                {
                    b.Property<int>("TicketModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumberOfViewingTickets")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ViewingModelId")
                        .HasColumnType("int");

                    b.HasKey("TicketModelId");

                    b.HasIndex("ViewingModelId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Berras_Bio_Lab1.Models.ViewingModel", b =>
                {
                    b.Property<int>("ViewingModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvaibleSeats")
                        .HasColumnType("int");

                    b.Property<int?>("MovieModelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TheaterModelId")
                        .HasColumnType("int");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.HasKey("ViewingModelId");

                    b.HasIndex("MovieModelId");

                    b.HasIndex("TheaterModelId");

                    b.ToTable("Viewings");
                });

            modelBuilder.Entity("Berras_Bio_Lab1.Models.TicketModel", b =>
                {
                    b.HasOne("Berras_Bio_Lab1.Models.ViewingModel", "Viewing")
                        .WithMany("tickets")
                        .HasForeignKey("ViewingModelId");
                });

            modelBuilder.Entity("Berras_Bio_Lab1.Models.ViewingModel", b =>
                {
                    b.HasOne("Berras_Bio_Lab1.Models.MovieModel", "Movie")
                        .WithMany("viewings")
                        .HasForeignKey("MovieModelId");

                    b.HasOne("Berras_Bio_Lab1.Models.TheaterModel", "Theater")
                        .WithMany("viewings")
                        .HasForeignKey("TheaterModelId");
                });
#pragma warning restore 612, 618
        }
    }
}
