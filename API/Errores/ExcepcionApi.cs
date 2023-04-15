namespace API.Errores
{
    public class ExcepcionApi : RespuestaApi
    {
        public ExcepcionApi(int statusCode, string mensaje = null,string detalle =null) : 
        base(statusCode, mensaje)
        {
            Detalle = detalle;
        }
        public string Detalle { get; set; }
    }
}