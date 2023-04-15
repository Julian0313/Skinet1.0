using Nucleo.Entidades;

namespace Nucleo.Especificaciones
{
    public class EspecificacionProductoConFiltrosConteo : EspecificacionBase<Producto>
    {
        public EspecificacionProductoConFiltrosConteo(EspecificacionProductoParametro productoParam)
        : base (x=>
            (string.IsNullOrEmpty(productoParam.Buscar) || x.nombre.ToLower().Contains
            (productoParam.Buscar)) &&
            (!productoParam.MarcaId.HasValue || x.marca_producto_id == productoParam.MarcaId) && 
            (!productoParam.TipoId.HasValue || x.tipo_productoid == productoParam.TipoId))
        {

        }
    }
}