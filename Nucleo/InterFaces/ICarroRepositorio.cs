using Nucleo.Entidades;

namespace Nucleo.InterFaces
{
    public interface ICarroRepositorio
    {
        Task<ClienteCarro>ObtenerCarroAsync(string carroId);
        Task<ClienteCarro>ActualizarCarroAsync(ClienteCarro carro);
        Task<bool>EliminarCarroAsync(string carroId);
    }
}