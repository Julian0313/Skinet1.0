using Nucleo.Entidades;

namespace Nucleo.Especificaciones
{
    public class ProductoConTipoYMarcaEspecificacion : EspecificacionBase<Producto>
    {
        public ProductoConTipoYMarcaEspecificacion(EspecificacionProductoParametro productoParam)
        : base (x=>
            (string.IsNullOrEmpty(productoParam.Buscar) || x.nombre.ToLower().Contains
            (productoParam.Buscar)) &&
            (!productoParam.MarcaId.HasValue || x.marca_producto_id == productoParam.MarcaId) && 
            (!productoParam.TipoId.HasValue || x.tipo_productoid == productoParam.TipoId))
        {
            AgregarIncluir(x=>x.tipo_producto);
            AgregarIncluir(x=>x.MarcaProducto);
            AgregarOrdenarPor(x=>x.nombre);
            AplicarPaginacion(productoParam.PageSize * (productoParam.PageIndex -1),
                productoParam.PageSize);
            if(!string.IsNullOrEmpty(productoParam.Orden))
            {
                switch(productoParam.Orden)
                {
                    case "precioAsc":
                        AgregarOrdenarPor(p=>p.precio);
                        break;
                    case "precioDesc":
                        AgregarOrdenarDescendente(p=>p.precio);
                        break;
                        default:
                        AgregarOrdenarPor(n=>n.nombre);
                        break;   
                }
            }
        }
        
        public ProductoConTipoYMarcaEspecificacion(int id):
        base(x=>x.id == id)
        {
            AgregarIncluir(x=>x.tipo_producto);
            AgregarIncluir(x=>x.MarcaProducto);
        }
    }
}