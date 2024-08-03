﻿// <auto-generated />
using Abigo.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Abigo.Infrastructure.Migrations
{
    [DbContext(typeof(AbigoDbAccess))]
    [Migration("20240803042222_UndoChanges")]
    partial class UndoChanges
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Abigo.Domain.Entities.AccountableEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AccessPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ConnectionEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("contactEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("contactPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("instagram")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Accountables");
                });

            modelBuilder.Entity("Abigo.Domain.Entities.AvailableLocalesEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<bool>("AcceptsAnimals")
                        .HasColumnType("boolean");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DonationKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LocaleNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NeighboorHood")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReferencePoint")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UF")
                        .HasColumnType("integer");

                    b.Property<int>("VacanciesNumber")
                        .HasColumnType("integer");

                    b.Property<string>("contactEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("contactPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("instagram")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AvailableLocales");
                });
#pragma warning restore 612, 618
        }
    }
}
