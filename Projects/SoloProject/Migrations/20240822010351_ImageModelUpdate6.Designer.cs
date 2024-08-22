﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoloProject.Context;

#nullable disable

namespace SoloProject.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240822010351_ImageModelUpdate6")]
    partial class ImageModelUpdate6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SoloProject.Models.Collection", b =>
                {
                    b.Property<int>("CollectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CollectionId"));

                    b.Property<string>("CollectionName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CoverImage")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ImagePaths")
                        .HasColumnType("longtext");

                    b.Property<string>("JournalEntry")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CollectionId");

                    b.HasIndex("UserId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("SoloProject.Models.Engagement", b =>
                {
                    b.Property<int>("EngagementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("EngagementId"));

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Like")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EngagementId");

                    b.HasIndex("CollectionId");

                    b.HasIndex("UserId");

                    b.ToTable("Engagements");
                });

            modelBuilder.Entity("SoloProject.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SoloProject.Models.Collection", b =>
                {
                    b.HasOne("SoloProject.Models.User", "User")
                        .WithMany("Collections")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SoloProject.Models.Engagement", b =>
                {
                    b.HasOne("SoloProject.Models.Collection", "Collection")
                        .WithMany("Engagements")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoloProject.Models.User", "User")
                        .WithMany("Engagements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SoloProject.Models.Collection", b =>
                {
                    b.Navigation("Engagements");
                });

            modelBuilder.Entity("SoloProject.Models.User", b =>
                {
                    b.Navigation("Collections");

                    b.Navigation("Engagements");
                });
#pragma warning restore 612, 618
        }
    }
}
