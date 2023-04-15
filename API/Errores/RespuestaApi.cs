namespace API.Errores
{
    public class RespuestaApi
    {
        public RespuestaApi(int statusCode, string mensaje = null)
        {
            StatusCode = statusCode;
            Mensaje = mensaje ?? ObtenerMensajePorCodigoEstado(statusCode);

        }

        public int StatusCode { get; set; }
        public string Mensaje { get; set; }

        private string ObtenerMensajePorCodigoEstado(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Autorized, you are not",
                404 => "Resource not found, it was not",
                500 => "Error are the path",
                _ => null
            };
        }
    }
}