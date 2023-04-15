using API.Dtos;
using AutoMapper;
using Nucleo.Entidades;

namespace API.Helppers
{
    public class MappingProducto : Profile
    {
        public MappingProducto()
        {
            CreateMap<Producto, ProductoDto>()
                .ForMember(d=>d.marca_producto,o=>o.MapFrom(s=>s.MarcaProducto.nombre))
                .ForMember(d=>d.tipo_producto,o=>o.MapFrom(s=>s.tipo_producto.nombre))
                .ForMember(d=>d.imagen_url,o => o.MapFrom<ResolverUrlProducto>());
        }
    }
}