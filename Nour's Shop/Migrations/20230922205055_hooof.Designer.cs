﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nour_Shop.Models;

#nullable disable

namespace Nour_Shop.Migrations
{
    [DbContext(typeof(NourShopContext))]
    [Migration("20230922205055_hooof")]
    partial class hooof
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Nour_Shop.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("date")
                        .HasColumnName("delivery date");

                    b.Property<decimal>("Number")
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("number");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("date")
                        .HasColumnName("order date");

                    b.Property<decimal>("Payment")
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("payment");

                    b.Property<int?>("Pid")
                        .HasColumnType("int");

                    b.Property<decimal?>("RemainingTime")
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("remaining time");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("status");

                    b.Property<decimal>("Times")
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("times");

                    b.Property<int?>("Uid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Pid");

                    b.HasIndex("Uid");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("Nour_Shop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Brand")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("brand")
                        .IsFixedLength();

                    b.Property<string>("Catogary")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("catogary")
                        .IsFixedLength();

                    b.Property<string>("Description")
                        .HasColumnType("ntext")
                        .HasColumnName("description");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("discount");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("ntext")
                        .HasColumnName("image");

                    b.Property<int?>("Oid")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("status")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("Oid");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("Nour_Shop.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("address");

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("age");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .HasColumnName("email")
                        .IsFixedLength();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nchar(15)")
                        .IsFixedLength();

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nchar(15)")
                        .IsFixedLength();

                    b.Property<int?>("Oid")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("password");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("sex")
                        .IsFixedLength();

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .IsFixedLength();

                    b.HasKey("Id")
                        .HasName("PK_User");

                    b.HasIndex("Oid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Nour_Shop.Models.Order", b =>
                {
                    b.HasOne("Nour_Shop.Models.Product", "PidNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("Pid")
                        .HasConstraintName("FK_orders_products");

                    b.HasOne("Nour_Shop.Models.User", "UidNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("Uid")
                        .HasConstraintName("FK_orders_Users");

                    b.Navigation("PidNavigation");

                    b.Navigation("UidNavigation");
                });

            modelBuilder.Entity("Nour_Shop.Models.Product", b =>
                {
                    b.HasOne("Nour_Shop.Models.Order", "OidNavigation")
                        .WithMany("Products")
                        .HasForeignKey("Oid")
                        .HasConstraintName("FK_products_orders");

                    b.Navigation("OidNavigation");
                });

            modelBuilder.Entity("Nour_Shop.Models.User", b =>
                {
                    b.HasOne("Nour_Shop.Models.Order", "OidNavigation")
                        .WithMany("Users")
                        .HasForeignKey("Oid")
                        .HasConstraintName("FK_Users_orders");

                    b.Navigation("OidNavigation");
                });

            modelBuilder.Entity("Nour_Shop.Models.Order", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Nour_Shop.Models.Product", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Nour_Shop.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
