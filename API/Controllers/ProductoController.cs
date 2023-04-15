using API.Dtos;
using API.Errores;
using API.Helppers;
using AutoMapper;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nucleo.Entidades;
using Nucleo.Especificaciones;
using Nucleo.InterFaces;

namespace API.Controllers
{
    public class ProductoController : BaseController
    {
        private readonly IRepositorioGenerico<Producto> _productoRepo;
        private readonly IRepositorioGenerico<TipoProducto> _tipoRepo;
        private readonly IRepositorioGenerico<MarcaProducto> _marcaRepo;
        private readonly IMapper _map;
        
        public ProductoController(IRepositorioGenerico<Producto> productoRepo,
        IRepositorioGenerico<TipoProducto> tipoRepo, IRepositorioGenerico<MarcaProducto> marcaRepo, IMapper map)
        {          
            _map = map;
            _marcaRepo = marcaRepo;
            _tipoRepo = tipoRepo;
            _productoRepo = productoRepo;
            
        }

        [HttpGet]
        public async Task<ActionResult<Paginacion<ProductoDto>>> ObtenerProductos(
            [FromQuery]EspecificacionProductoParametro productoParam)
        {
            var espec = new ProductoConTipoYMarcaEspecificacion(productoParam);
            var contarEspec = new EspecificacionProductoConFiltrosConteo(productoParam);
            var totalItems = await _productoRepo.ContarAsync(contarEspec);
            var productos = await _productoRepo.ListarAsync(espec);
            var data = _map
                .Map<IReadOnlyList<Producto>,IReadOnlyList<ProductoDto>>(productos);
            return Ok(new Paginacion<ProductoDto>(productoParam.PageIndex,productoParam.PageSize,
            totalItems,data));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespuestaApi),StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductoDto>> ObtenerProductos(int id)
        {
            var espec = new ProductoConTipoYMarcaEspecificacion(id);
            var producto = await _productoRepo.ObtenerEntidadConEspecificacion(espec);
            if (producto == null) return NotFound(new RespuestaApi(404));
            return _map.Map<Producto,ProductoDto>(producto);
        }
        [HttpGet("marca")]
        public async Task<ActionResult<IReadOnlyList<MarcaProducto>>> ObtenerMarcaProducto()
        {
            return Ok(await _marcaRepo.ListarAsync());
        }
        [HttpGet("tipo")]
        public async Task<ActionResult<IReadOnlyList<TipoProducto>>> Obtenertipo_producto()
        {            
            return Ok(await _tipoRepo.ListarAsync());
        }
    }
}