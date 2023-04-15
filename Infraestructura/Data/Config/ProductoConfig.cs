using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nucleo.Entidades;

namespace Infraestructura.Data.Config
{
    public class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(p => p.nombre).IsRequired().HasMaxLength(100);
            builder.Property(p => p.descripcion).IsRequired().HasMaxLength(750);
            builder.Property(p => p.precio).HasColumnType("decimal(18,2)");
            builder.Property(p => p.imagen_url).IsRequired();          
            builder.HasOne(t => t.tipo_producto).WithMany()
                .HasForeignKey(p => p.tipo_productoid);
            builder.HasOne(m => m.MarcaProducto).WithMany()
                .HasForeignKey(p => p.marca_producto_id);  
        }
    }
}