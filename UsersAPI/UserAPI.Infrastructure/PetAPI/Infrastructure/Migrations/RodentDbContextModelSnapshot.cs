﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserAPI.Infrastructure.DbContext;

#nullable disable

namespace UserAPI.Infrastructure.UserAPI.Infrastructure.Migrations
{
    [DbContext(typeof(UserDbContext))]
    partial class UserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("UserAPI.Core.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Habitat")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5acb1435-8cc9-42e4-a365-dfa8f9c88d26"),
                            Age = 2,
                            DateOfBirth = new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A common city rat.",
                            Habitat = "Urban Areas",
                            Name = "Ratty",
                            Species = "Rat",
                            Weight = 250f
                        },
                        new
                        {
                            Id = new Guid("32e7a77e-0146-4b15-b7f8-58c447641910"),
                            Age = 1,
                            DateOfBirth = new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A small house mouse.",
                            Habitat = "Houses",
                            Name = "Mickey",
                            Species = "Mouse",
                            Weight = 30f
                        },
                        new
                        {
                            Id = new Guid("ab16dbca-ef93-4c7b-855d-774f89cfab69"),
                            Age = 3,
                            DateOfBirth = new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A forest chipmunk with distinctive stripes.",
                            Habitat = "Forests",
                            Name = "Chippy",
                            Species = "Chipmunk",
                            Weight = 100f
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
