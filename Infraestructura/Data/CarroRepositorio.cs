using System.Text.Json;
using Nucleo.Entidades;
using Nucleo.InterFaces;
using StackExchange.Redis;

namespace Infraestructura.Data
{
    public class CarroRepositorio : ICarroRepositorio
    {
        private readonly IDatabase _dataBase;
        public CarroRepositorio(IConnectionMultiplexer redis)
        {
            _dataBase = redis.GetDatabase();
        }

        public async Task<ClienteCarro> ActualizarCarroAsync(ClienteCarro carro)
        {
            var crear = await _dataBase.StringSetAsync(carro.id,
            JsonSerializer.Serialize(carro),TimeSpan.FromDays(30));
            if(!crear) return null;
            return await ObtenerCarroAsync(carro.id);
        }

        public async Task<bool> EliminarCarroAsync(string carroId)
        {
            return await _dataBase.KeyDeleteAsync(carroId);
        }

        public async Task<ClienteCarro> ObtenerCarroAsync(string carroId)
        {
            var data = await _dataBase.StringGetAsync(carroId);
            return data.IsNullOrEmpty ? null: JsonSerializer.Deserialize<ClienteCarro>(data);
        }
    }
}