﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using newwebapi.Context;

namespace newwebapi.Migrations
{
    [DbContext(typeof(ApiAppContext))]
    partial class ApiAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("newwebapi.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("dcd9ed64-cb78-4c87-9b26-9204919d4249"),
                            Active = true,
                            DateCreated = new DateTime(2021, 4, 30, 11, 56, 51, 897, DateTimeKind.Local).AddTicks(5513),
                            LastName = "Guaman",
                            Name = "Vero"
                        },
                        new
                        {
                            UserId = new Guid("9cabd999-c5ca-45b3-8863-a0b474f52f1b"),
                            Active = true,
                            DateCreated = new DateTime(2021, 4, 30, 11, 56, 51, 899, DateTimeKind.Local).AddTicks(3853),
                            LastName = "LastName 1",
                            Name = "User 1"
                        },
                        new
                        {
                            UserId = new Guid("4e175d31-82bf-404d-bc97-783e47d27b03"),
                            Active = true,
                            DateCreated = new DateTime(2021, 4, 30, 11, 56, 51, 899, DateTimeKind.Local).AddTicks(3924),
                            LastName = "LastName 2",
                            Name = "User 2"
                        });
                });

            modelBuilder.Entity("newwebapi.Models.UserRole", b =>
                {
                    b.Property<Guid>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserRoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            UserRoleId = new Guid("68d6dd14-6beb-4180-a112-e49c4737383e"),
                            Active = true,
                            Role = "Admin",
                            UserId = new Guid("dcd9ed64-cb78-4c87-9b26-9204919d4249")
                        },
                        new
                        {
                            UserRoleId = new Guid("865ef134-a1a9-4b61-bf61-ab203e5dbb4a"),
                            Active = true,
                            Role = "User",
                            UserId = new Guid("dcd9ed64-cb78-4c87-9b26-9204919d4249")
                        },
                        new
                        {
                            UserRoleId = new Guid("adabe337-33bf-49db-ba9a-b5e6859c9286"),
                            Active = true,
                            Role = "Support",
                            UserId = new Guid("dcd9ed64-cb78-4c87-9b26-9204919d4249")
                        },
                        new
                        {
                            UserRoleId = new Guid("0e7282d2-0f91-4f9b-8777-21c23e0ab1ee"),
                            Active = true,
                            Role = "Support",
                            UserId = new Guid("9cabd999-c5ca-45b3-8863-a0b474f52f1b")
                        });
                });

            modelBuilder.Entity("newwebapi.Models.UserRole", b =>
                {
                    b.HasOne("newwebapi.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}