using Microsoft.EntityFrameworkCore;
using Nucleo.Entidades;
using Nucleo.Especificaciones;
using Nucleo.InterFaces;

namespace Infraestructura.Data
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : EntidadBase
    {
        private readonly TiendaContexto _contexto;
        public RepositorioGenerico(TiendaContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> ContarAsync(IEspecificacion<T> espec)
        {
            return await AplicarEspecificacion(espec).CountAsync();
        }

        public async Task<IReadOnlyList<T>> ListarAsync()
        {
            return await _contexto.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListarAsync(IEspecificacion<T> espec)
        {
            return await AplicarEspecificacion(espec).ToListAsync();
        }

        public async Task<T> ObtenerEntidadConEspecificacion(IEspecificacion<T> espec)
        {
            return await AplicarEspecificacion(espec).FirstOrDefaultAsync();
        }

        public async Task<T> ObtenerIdAsync(int id)
        {
            return await _contexto.Set<T>().FindAsync(id);
        }
        private IQueryable<T> AplicarEspecificacion(IEspecificacion<T> espec)
        {
            return EvaluadorEspecificaciones<T>.ObtenerConsulta(_contexto.Set<T>().AsQueryable(),espec);
        }
    }
}