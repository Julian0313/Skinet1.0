namespace Nucleo.Entidades
{
    public class Producto : EntidadBase
    { 
     public string nombre { get; set; }
     public string descripcion { get; set; }
     public decimal precio { get; set; }
     public string imagen_url { get; set; }
     public TipoProducto tipo_producto { get; set; }
     public int tipo_productoid { get; set; }
     public MarcaProducto MarcaProducto { get; set; }
     public int marca_producto_id { get; set; }
    }
}