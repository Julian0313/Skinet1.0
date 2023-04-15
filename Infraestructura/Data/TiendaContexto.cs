using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Nucleo.Entidades;

namespace Infraestructura.Data
{
    public class TiendaContexto : DbContext
    {
        public TiendaContexto(DbContextOptions<TiendaContexto> options) : base
        (options)
        {
            }
        public DbSet<Producto> Productos {get; set;}
        public DbSet<MarcaProducto> MarcaProductos { get; set; }
        public DbSet<TipoProducto> TipoProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}