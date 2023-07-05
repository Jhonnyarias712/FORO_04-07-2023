﻿// <auto-generated />
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleApp1.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20230705040334_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ConsoleApp1.Models.Auto", b =>
                {
                    b.Property<int>("Autoid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Autoid"), 1L, 1);

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<int>("Colorid")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Propietarioid")
                        .HasColumnType("int");

                    b.HasKey("Autoid");

                    b.HasIndex("Colorid");

                    b.HasIndex("Propietarioid");

                    b.ToTable("autos");
                });

            modelBuilder.Entity("ConsoleApp1.Models.Color", b =>
                {
                    b.Property<int>("Colorid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Colorid"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Colorid");

                    b.ToTable("colores");
                });

            modelBuilder.Entity("ConsoleApp1.Models.Propietario", b =>
                {
                    b.Property<int>("Propietarioid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Propietarioid"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Propietarioid");

                    b.ToTable("propietarios");
                });

            modelBuilder.Entity("ConsoleApp1.Models.Auto", b =>
                {
                    b.HasOne("ConsoleApp1.Models.Color", "colorid")
                        .WithMany()
                        .HasForeignKey("Colorid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleApp1.Models.Propietario", "propietarioid")
                        .WithMany()
                        .HasForeignKey("Propietarioid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("colorid");

                    b.Navigation("propietarioid");
                });
#pragma warning restore 612, 618
        }
    }
}
