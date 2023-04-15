namespace Nucleo.Entidades
{
    public class ItemCarro
    {
        public int id {get; set;}
        public string nombreProducto { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public string imagen_url { get; set; }                                                
        public string marca { get; set; }
        public string tipo_producto { get; set; }
    }
}