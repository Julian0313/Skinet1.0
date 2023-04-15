using System.Text.Json;
using Microsoft.Extensions.Logging;
using Nucleo.Entidades;

namespace Infraestructura.Data
{
    public class TiendaContextoSeed
    {
        public static async Task SeedAsync(TiendaContexto contexto, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!contexto.TipoProductos.Any())
                {
                    var tipo_productoData =
                        File.ReadAllText("../Infraestructura/Data/SeedData/tipoProductos.json");
                    var TipoProductos = JsonSerializer.Deserialize<List<TipoProducto>>(tipo_productoData);

                    foreach (var item in TipoProductos)
                    {
                        contexto.TipoProductos.Add(item);
                    }
                    await contexto.SaveChangesAsync();
                }
                if (!contexto.MarcaProductos.Any())
                {
                    var marcaData =
                        File.ReadAllText("../Infraestructura/Data/SeedData/Marcas.json");
                    var marcas = JsonSerializer.Deserialize<List<MarcaProducto>>(marcaData);

                    foreach (var item in marcas)
                    {
                        contexto.MarcaProductos.Add(item);
                    }
                    await contexto.SaveChangesAsync();
                }

                // if(!contexto.Productos.Any())
                // {
                //     var productosData = 
                //         File.ReadAllText("../Infraestructura/Data/SeedData/Productos.json");
                //     var producto = JsonSerializer.Deserialize<List<Producto>>(productosData);

                //     foreach(var item in producto)
                //     {
                //         contexto.Productos.Add(item);
                //     }
                //     await contexto.SaveChangesAsync();
                // }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<TiendaContextoSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}