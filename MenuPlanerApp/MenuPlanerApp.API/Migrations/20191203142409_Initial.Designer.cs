﻿// <auto-generated />
using System;
using MenuPlanerApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MenuPlanerApp.API.Migrations
{
    [DbContext(typeof(MenuPlanerAppAPIContext))]
    [Migration("20191203142409_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MenuPlanerApp.API.Model.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<bool>("CompatibleForCeliac")
                        .HasColumnType("bit");

                    b.Property<bool>("CompatibleForFructose")
                        .HasColumnType("bit");

                    b.Property<bool>("CompatibleForHistamin")
                        .HasColumnType("bit");

                    b.Property<bool>("CompatibleForLactose")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.Property<string>("ReferenceUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("MenuPlanerApp.API.Model.MenuPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MenuPlan");
                });

            modelBuilder.Entity("MenuPlanerApp.API.Model.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<byte[]>("DirectionPictures")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.Property<int>("MealDayTime")
                        .HasColumnType("int");

                    b.Property<int?>("MenuPlanId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<int>("NumbersOfMeals")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuPlanId");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("MenuPlanerApp.API.Model.Ingredient", b =>
                {
                    b.HasOne("MenuPlanerApp.API.Model.Recipe", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("MenuPlanerApp.API.Model.Recipe", b =>
                {
                    b.HasOne("MenuPlanerApp.API.Model.MenuPlan", null)
                        .WithMany("Recipes")
                        .HasForeignKey("MenuPlanId");
                });
#pragma warning restore 612, 618
        }
    }
}
