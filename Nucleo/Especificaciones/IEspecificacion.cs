using System.Linq.Expressions;

namespace Nucleo.Especificaciones
{
    public interface IEspecificacion<T>
    {
        Expression<Func<T,bool>> Criterio{get;}
        List<Expression<Func<T, object>>> Incluir{get;}
        Expression<Func<T, object>> OrdenarPor {get; }
        Expression<Func<T, object>> OrdenDescendente {get; }
        int Atras{get;}
        int Adelante{get;}
        bool PaginacionActiva{get;}

    }
}