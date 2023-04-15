using Nucleo.Entidades;

namespace Nucleo.InterFaces
{
    public interface IProductoRepositorio
    {
        Task<Producto>ObtenerProductoPorIdAsync(int id);        

        Task<IReadOnlyList<Producto>>ObtenerProductosAsync();
        Task<IReadOnlyList<TipoProducto>>ObtenerTipoProductosAsync();
        Task<IReadOnlyList<MarcaProducto>>ObtenerMarcaProductosAsync();
    }
}