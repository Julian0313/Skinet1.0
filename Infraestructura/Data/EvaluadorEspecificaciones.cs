using Microsoft.EntityFrameworkCore;
using Nucleo.Entidades;
using Nucleo.Especificaciones;

namespace Infraestructura.Data
{
    public class EvaluadorEspecificaciones<TEntity> where TEntity : EntidadBase
    {
        public static IQueryable<TEntity>ObtenerConsulta(IQueryable<TEntity> consulta,
         IEspecificacion<TEntity> espec)
         {
            var Consulta = consulta;
            if(espec.Criterio != null)
            {
                Consulta = Consulta.Where(espec.Criterio); // P=>p.tipo_productoid == id
            }
            if(espec.OrdenarPor != null)
            {
                Consulta = Consulta.OrderBy(espec.OrdenarPor);
            }
            if(espec.OrdenDescendente != null)
            {
                Consulta = Consulta.OrderByDescending(espec.OrdenDescendente);
            }
            if(espec.PaginacionActiva)
            {
                Consulta = Consulta.Skip(espec.Adelante).Take(espec.Atras);
            }
            Consulta = espec.Incluir.Aggregate(Consulta,(current, include)=>current.Include(include));
            return Consulta;
         }
        
    }
}