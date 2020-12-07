﻿// <auto-generated />
using System;
using ClinicaVeterinaria.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClinicaVeterinaria.Migrations
{
    [DbContext(typeof(VeterinariaContext))]
    [Migration("20201124222359_2")]
    partial class _2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClinicaVeterinaria.Models.Atendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BichinhoId")
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResponsavelId")
                        .HasColumnType("int");

                    b.Property<int>("VeterinarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BichinhoId");

                    b.HasIndex("ResponsavelId");

                    b.HasIndex("VeterinarioId");

                    b.ToTable("Atendimentos");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.BanhoTosa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BichinhoId")
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResponsavelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BichinhoId");

                    b.HasIndex("ResponsavelId");

                    b.ToTable("BanhoTosa");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Bichinho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adocao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataNascimento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Especie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResponsavelId")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ResponsavelId");

                    b.ToTable("Bichinhos");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Responsavel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataNascimento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Responsaveis");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Veterinario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CRMV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Veterinario");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Atendimento", b =>
                {
                    b.HasOne("ClinicaVeterinaria.Models.Bichinho", "Bichinho")
                        .WithMany()
                        .HasForeignKey("BichinhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaVeterinaria.Models.Responsavel", "Responsavel")
                        .WithMany()
                        .HasForeignKey("ResponsavelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaVeterinaria.Models.Veterinario", "Veterinario")
                        .WithMany()
                        .HasForeignKey("VeterinarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.BanhoTosa", b =>
                {
                    b.HasOne("ClinicaVeterinaria.Models.Bichinho", "Bichinho")
                        .WithMany()
                        .HasForeignKey("BichinhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaVeterinaria.Models.Responsavel", "Responsavel")
                        .WithMany()
                        .HasForeignKey("ResponsavelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Bichinho", b =>
                {
                    b.HasOne("ClinicaVeterinaria.Models.Responsavel", "Responsavel")
                        .WithMany()
                        .HasForeignKey("ResponsavelId");
                });
#pragma warning restore 612, 618
        }
    }
}