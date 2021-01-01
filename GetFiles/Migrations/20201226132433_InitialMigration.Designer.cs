﻿// <auto-generated />
using System;
using GetFiles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GetFiles.Migrations
{
    [DbContext(typeof(AppdbContext))]
    [Migration("20201226132433_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("GetFiles.Models.dataBaseModel.Video", b =>
                {
                    b.Property<Guid>("idVideo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("VideoCourseidCourse")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nameOfVideo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idVideo");

                    b.HasIndex("VideoCourseidCourse");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("GetFiles.Models.dataBaseModel.VideoCourse", b =>
                {
                    b.Property<Guid>("idCourse")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameOfCourse")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCourse");

                    b.ToTable("VideoCourse");
                });

            modelBuilder.Entity("GetFiles.Models.dataBaseModel.Video", b =>
                {
                    b.HasOne("GetFiles.Models.dataBaseModel.VideoCourse", "VideoCourse")
                        .WithMany("Video")
                        .HasForeignKey("VideoCourseidCourse");

                    b.Navigation("VideoCourse");
                });

            modelBuilder.Entity("GetFiles.Models.dataBaseModel.VideoCourse", b =>
                {
                    b.Navigation("Video");
                });
#pragma warning restore 612, 618
        }
    }
}
