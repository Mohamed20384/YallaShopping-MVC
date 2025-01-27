﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YallaShopping.DataAccess.Data;

#nullable disable

namespace YallaShopping.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241101143646_AddCategoryToDb")]
    partial class AddCategoryToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.2.24474.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("YallaShopping_Web.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(29)
                        .HasColumnType("nvarchar(29)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Programs"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Arts"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Cars"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "Kids"
                        },
                        new
                        {
                            Id = 5,
                            DisplayOrder = 5,
                            Name = "Books"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
