namespace API.Dtos
{
    public class ProductoDto
    {       
     public int id { get; set; }
     public string nombre { get; set; }
     public string descripcion { get; set; }
     public decimal precio { get; set; }
     public string imagen_url { get; set; }
     public string tipo_producto { get; set; }
     public string marca_producto { get; set; }
    }
}