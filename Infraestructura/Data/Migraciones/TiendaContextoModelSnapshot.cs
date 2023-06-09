﻿// <auto-generated />
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructura.Data.Migraciones
{
    [DbContext(typeof(TiendaContexto))]
    partial class TiendaContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Nucleo.Entidades.MarcaProducto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("MarcaProductos");
                });

            modelBuilder.Entity("Nucleo.Entidades.Producto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(750)
                        .HasColumnType("nvarchar(750)");

                    b.Property<string>("imagen_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("marca_producto_id")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("tipo_productoid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("marca_producto_id");

                    b.HasIndex("tipo_productoid");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Nucleo.Entidades.tipo_producto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("TipoProductos");
                });

            modelBuilder.Entity("Nucleo.Entidades.Producto", b =>
                {
                    b.HasOne("Nucleo.Entidades.MarcaProducto", "marca_producto")
                        .WithMany()
                        .HasForeignKey("marca_producto_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nucleo.Entidades.tipo_producto", "tipo_producto")
                        .WithMany()
                        .HasForeignKey("tipo_productoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("marca_producto");

                    b.Navigation("tipo_producto");
                });
#pragma warning restore 612, 618
        }
    }
}
