using Microsoft.EntityFrameworkCore;
using Nucleo.Entidades;
using Nucleo.InterFaces;

namespace Infraestructura.Data
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly TiendaContexto _contexto;
        public ProductoRepositorio(TiendaContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IReadOnlyList<MarcaProducto>> ObtenerMarcaProductosAsync()
        {
            return await _contexto.MarcaProductos.ToListAsync();
        }

        public async Task<Producto> ObtenerProductoPorIdAsync(int id)
        {
            return await _contexto.Productos            
            .Include(p=>p.tipo_producto)
            .Include(p=>p.MarcaProducto)
            .FirstOrDefaultAsync(p=>p.id==id);
        }

        public async Task<IReadOnlyList<Producto>> ObtenerProductosAsync()
        {
            return await _contexto.Productos
            .Include(p=>p.tipo_producto)
            .Include(p=>p.MarcaProducto)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<TipoProducto>> ObtenerTipoProductosAsync()
        {
            return await _contexto.TipoProductos.ToListAsync();
        }
    }
}