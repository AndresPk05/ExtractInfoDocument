﻿// <auto-generated />
using System;
using ExtractInfoDocument.INFRASTRUCTURE.MODEL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExtractInfoDocument.Migrations
{
    [DbContext(typeof(ExtractionInfoDocumentContext))]
    [Migration("20240614152116_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExtractInfoDocument.BUISNESS_LOGIC.ENTITIES.ExtractionDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExtractionPerformedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameDocument")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ExtractionPerformedId");

                    b.ToTable("ExtractionDetails");
                });

            modelBuilder.Entity("ExtractInfoDocument.BUISNESS_LOGIC.ENTITIES.ExtractionPerformed", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("License")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ExtractionPerformeds");
                });

            modelBuilder.Entity("ExtractInfoDocument.BUISNESS_LOGIC.ENTITIES.ExtractionDetail", b =>
                {
                    b.HasOne("ExtractInfoDocument.BUISNESS_LOGIC.ENTITIES.ExtractionPerformed", "ExtractionPerformed")
                        .WithMany("Details")
                        .HasForeignKey("ExtractionPerformedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtractionPerformed");
                });

            modelBuilder.Entity("ExtractInfoDocument.BUISNESS_LOGIC.ENTITIES.ExtractionPerformed", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
