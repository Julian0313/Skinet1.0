using System.Linq.Expressions;

namespace Nucleo.Especificaciones
{
    public class EspecificacionBase<T> : IEspecificacion<T>
    {
        public EspecificacionBase()
        {

        }
        public EspecificacionBase(Expression<Func<T, bool>> criterio)
        {
            Criterio = criterio;
        }

        public Expression<Func<T, bool>> Criterio { get; }

        public List<Expression<Func<T, object>>> Incluir { get; } =
            new List<Expression<Func<T, object>>>();
        public Func<object, bool> Value { get; }

        public Expression<Func<T, object>> OrdenarPor { get; private set; }

        public Expression<Func<T, object>> OrdenDescendente { get; private set; }

        public int Atras { get; private set; }

        public int Adelante { get; private set; }

        public bool PaginacionActiva { get; private set; }

        protected void AgregarIncluir(Expression<Func<T, object>> incluirExpresion)
        {
            Incluir.Add(incluirExpresion);
        }

        protected void AgregarOrdenarPor(Expression<Func<T, object>> oredenarPorExp)
        {
            OrdenarPor = oredenarPorExp;
        }
        protected void AgregarOrdenarDescendente(Expression<Func<T, object>> ordenDesc)
        {
            OrdenDescendente = ordenDesc;
        }
        protected void AplicarPaginacion(int adelante, int atras)
        {
            Adelante = adelante;
            Atras = atras;
            PaginacionActiva = true;
        }
    }
}