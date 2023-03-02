﻿// <auto-generated />
using GestionEtudiants.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionEtudiants.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230211103723_AddEntities")]
    partial class AddEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionEtudiants.Models.Adresse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("GestionEtudiants.Models.Filiere", b =>
                {
                    b.Property<int>("FiliereId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FiliereId"));

                    b.Property<string>("FiliereName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FiliereId");

                    b.ToTable("Filieres");
                });

            modelBuilder.Entity("GestionEtudiants.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("FiliereId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("FiliereId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("GestionEtudiants.Models.Adresse", b =>
                {
                    b.HasOne("GestionEtudiants.Models.Student", "Student")
                        .WithMany("Adresses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("GestionEtudiants.Models.Student", b =>
                {
                    b.HasOne("GestionEtudiants.Models.Filiere", "Filiere")
                        .WithMany("Students")
                        .HasForeignKey("FiliereId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filiere");
                });

            modelBuilder.Entity("GestionEtudiants.Models.Filiere", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("GestionEtudiants.Models.Student", b =>
                {
                    b.Navigation("Adresses");
                });
#pragma warning restore 612, 618
        }
    }
}
