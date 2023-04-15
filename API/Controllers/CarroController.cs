using Microsoft.AspNetCore.Mvc;
using Nucleo.Entidades;
using Nucleo.InterFaces;

namespace API.Controllers
{
    public class CarroController : BaseController
    {
        private readonly ICarroRepositorio _carroRepo;
        public CarroController(ICarroRepositorio carroRepo)
        {
            _carroRepo = carroRepo;
        }
        [HttpGet]
        public async Task<ActionResult<ClienteCarro>>ObtenerCarroId(string id)
        {
            var carro = await _carroRepo.ObtenerCarroAsync(id);
            return Ok(carro ?? new ClienteCarro(id));
        }
        [HttpPost]
        public async Task<ActionResult<ClienteCarro>>ActualizarCarro(ClienteCarro carro)
        {
            var actualizarCarro = await _carroRepo.ActualizarCarroAsync(carro);
            return Ok(actualizarCarro);
        }
        [HttpDelete]
        public async Task EliminarCarroAsync(string id)
        {
            await _carroRepo.EliminarCarroAsync(id);
        }
    }
}