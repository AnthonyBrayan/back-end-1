﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ServiceContext))]
    [Migration("20230802094909_AddImg")]
    partial class AddImg
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Brand", b =>
                {
                    b.Property<int>("Id_brand")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_brand"));

                    b.Property<string>("name_brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_brand");

                    b.ToTable("Brand", (string)null);
                });

            modelBuilder.Entity("Entities.Customer", b =>
                {
                    b.Property<int>("Id_customer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_customer"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdTypeUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Name_customer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_customer");

                    b.HasIndex("IdTypeUsuario");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Entities.Order_detail", b =>
                {
                    b.Property<int>("Id_order_detail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_order_detail"));

                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id_order_detail");

                    b.HasIndex("IdOrder");

                    b.HasIndex("IdProduct");

                    b.ToTable("Order_detail", (string)null);
                });

            modelBuilder.Entity("Entities.Orders", b =>
                {
                    b.Property<int>("Id_order")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_order"));

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPedido")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("int");

                    b.Property<string>("Order_status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Totalamount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id_order");

                    b.HasIndex("IdCustomer");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("Entities.ProductItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_brand")
                        .HasColumnType("int");

                    b.Property<int>("Id_supplier")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id_brand");

                    b.HasIndex("Id_supplier");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Entities.Supplier", b =>
                {
                    b.Property<int>("Id_supplier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_supplier"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdTypeUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name_supplier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_supplier");

                    b.HasIndex("IdTypeUsuario");

                    b.ToTable("Supplier", (string)null);
                });

            modelBuilder.Entity("Entities.TypeUsuario", b =>
                {
                    b.Property<int>("Id_TypeUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_TypeUser"));

                    b.Property<string>("TypeUser_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_TypeUser");

                    b.ToTable("TypeUsuario", (string)null);
                });

            modelBuilder.Entity("Entities.Customer", b =>
                {
                    b.HasOne("Entities.TypeUsuario", "TypeUsuario")
                        .WithMany("Customer")
                        .HasForeignKey("IdTypeUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeUsuario");
                });

            modelBuilder.Entity("Entities.Order_detail", b =>
                {
                    b.HasOne("Entities.Orders", "Orders")
                        .WithMany("order_Detail")
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.ProductItem", "Product")
                        .WithMany()
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Orders", b =>
                {
                    b.HasOne("Entities.Customer", "Custumer")
                        .WithMany("orders")
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Custumer");
                });

            modelBuilder.Entity("Entities.ProductItem", b =>
                {
                    b.HasOne("Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("Id_brand")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("Id_supplier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Entities.Supplier", b =>
                {
                    b.HasOne("Entities.TypeUsuario", "TypeUsuario")
                        .WithMany("Supplier")
                        .HasForeignKey("IdTypeUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeUsuario");
                });

            modelBuilder.Entity("Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Customer", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("Entities.Orders", b =>
                {
                    b.Navigation("order_Detail");
                });

            modelBuilder.Entity("Entities.Supplier", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.TypeUsuario", b =>
                {
                    b.Navigation("Customer");

                    b.Navigation("Supplier");
                });
#pragma warning restore 612, 618
        }
    }
}
