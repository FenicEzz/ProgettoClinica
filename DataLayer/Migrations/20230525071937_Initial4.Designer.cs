﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(ClinicaDbContext))]
    [Migration("20230525071937_Initial4")]
    partial class Initial4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataLayer.Entities.Acceptance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("PetId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("Acceptances");
                });

            modelBuilder.Entity("DataLayer.Entities.Examination", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AcceptanceId")
                        .HasColumnType("bigint");

                    b.Property<string>("Disease")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExaminationDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("PetId")
                        .HasColumnType("bigint");

                    b.Property<string>("Treatment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AcceptanceId");

                    b.HasIndex("PetId");

                    b.ToTable("Examinations");
                });

            modelBuilder.Entity("DataLayer.Entities.Pet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerFirstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerLastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FurColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasMicrochip")
                        .HasColumnType("bit");

                    b.Property<int?>("MicrochipNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("DataLayer.Entities.Recovery", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ExaminationId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RecoveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UrlPetPicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExaminationId");

                    b.ToTable("Recoveries");
                });

            modelBuilder.Entity("DataLayer.Entities.Acceptance", b =>
                {
                    b.HasOne("DataLayer.Entities.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("DataLayer.Entities.Examination", b =>
                {
                    b.HasOne("DataLayer.Entities.Acceptance", "Acceptance")
                        .WithMany()
                        .HasForeignKey("AcceptanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.Pet", null)
                        .WithMany("Examinations")
                        .HasForeignKey("PetId");

                    b.Navigation("Acceptance");
                });

            modelBuilder.Entity("DataLayer.Entities.Recovery", b =>
                {
                    b.HasOne("DataLayer.Entities.Examination", "Examination")
                        .WithMany()
                        .HasForeignKey("ExaminationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Examination");
                });

            modelBuilder.Entity("DataLayer.Entities.Pet", b =>
                {
                    b.Navigation("Examinations");
                });
#pragma warning restore 612, 618
        }
    }
}
