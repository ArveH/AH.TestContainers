﻿// <auto-generated />
using AH.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AH.Migrations.Postgres.Migrations
{
    [DbContext(typeof(AhDbContext))]
    [Migration("20240827103205_AddNamingConvention")]
    partial class AddNamingConvention
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:CollationDefinition:en_ci_ai", "en-u-ks-level1,en-u-ks-level1,icu,False")
                .HasAnnotation("Npgsql:CollationDefinition:en_ci_as", "en-u-ks-level2,en-u-ks-level2,icu,False")
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AH.Database.Entities.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("firstname")
                        .UseCollation("en_ci_ai");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("lastname")
                        .UseCollation("en_ci_ai");

                    b.HasKey("Id")
                        .HasName("pk_people");

                    b.ToTable("people", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 2L,
                            FirstName = "Jane",
                            LastName = "Doe"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
