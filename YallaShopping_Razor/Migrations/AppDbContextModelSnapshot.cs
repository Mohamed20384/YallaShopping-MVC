﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YallaShopping_Razor.Data;

#nullable disable

namespace YallaShopping_Razor.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.2.24474.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_CommerceRazor_Temp.Models.Category", b =>
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
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Healthy Food"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Kids"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "Food"
                        },
                        new
                        {
                            Id = 5,
                            DisplayOrder = 5,
                            Name = "Sweet"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
