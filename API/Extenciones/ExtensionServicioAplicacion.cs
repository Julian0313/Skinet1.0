using API.Errores;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Nucleo.InterFaces;

namespace API.Extenciones
{
    public static class ExtensionServicioAplicacion
    {
        public static IServiceCollection AddServiciosAplicacion(this IServiceCollection services)
        {            
            services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
            services.AddScoped<ICarroRepositorio, CarroRepositorio>();
            services.AddScoped(typeof(IRepositorioGenerico<>),(typeof(RepositorioGenerico<>)));  
            services.Configure<ApiBehaviorOptions>(options =>
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var error = actionContext.ModelState
                    .Where(e=> e.Value.Errors.Count>0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x=>x.ErrorMessage).ToArray();

                var repuestaError = new ApiValidacionRespuestaError
                {
                    Error = error
                };
                return new BadRequestObjectResult(repuestaError);
            });
            return services;
        }        
    }
}