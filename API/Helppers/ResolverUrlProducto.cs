using API.Dtos;
using AutoMapper;
using Nucleo.Entidades;

namespace API.Helppers
{
    public class ResolverUrlProducto : IValueResolver<Producto, ProductoDto, string>
    {
        private readonly IConfiguration _config;
        public ResolverUrlProducto(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Producto source, ProductoDto destination, string destMember, 
        ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.imagen_url))
            {
                return _config["ApiUrl"]+source.imagen_url;
            }
            return null;
        }
    }
}