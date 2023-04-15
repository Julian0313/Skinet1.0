using Nucleo.Entidades;
using Nucleo.Especificaciones;

namespace Nucleo.InterFaces
{
    public interface IRepositorioGenerico<T> where T : EntidadBase
    {
        Task<T> ObtenerIdAsync(int id);
        Task<IReadOnlyList<T>> ListarAsync();     
        Task<T> ObtenerEntidadConEspecificacion(IEspecificacion<T> espec);           
        Task<IReadOnlyList<T>> ListarAsync(IEspecificacion<T> espec);
        Task<int> ContarAsync(IEspecificacion<T> espec);
    }
}