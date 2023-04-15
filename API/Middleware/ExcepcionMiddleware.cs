using System.Net;
using System.Text.Json;
using API.Errores;

namespace API.Middleware
{
    public class ExcepcionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExcepcionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public ExcepcionMiddleware(RequestDelegate next, ILogger<ExcepcionMiddleware> logger,

        IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                ? new ExcepcionApi((int)HttpStatusCode.InternalServerError, ex.Message,
                ex.StackTrace.ToString())
                : new RespuestaApi((int)HttpStatusCode.InternalServerError);

                var opciones = new JsonSerializerOptions{PropertyNamingPolicy = 
                JsonNamingPolicy.CamelCase};

                var json = JsonSerializer.Serialize(response, opciones);

                await context.Response.WriteAsync(json);
            }
        }
    }
}