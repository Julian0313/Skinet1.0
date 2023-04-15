namespace API.Errores
{
    public class ApiValidacionRespuestaError : RespuestaApi
    {
        public ApiValidacionRespuestaError() : base(400)
        {
        }
        public IEnumerable<string> Error { get; set; }
    }
}