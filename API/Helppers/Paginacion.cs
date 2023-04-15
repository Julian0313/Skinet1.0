namespace API.Helppers
{
    public class Paginacion<T> where T : class
    {
        public Paginacion(int pageIndex, int pageSize, int contador, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Contador = contador;
            Data = data;
        }

        public int PageIndex { get; set; }        
        public int PageSize { get; set; }
        public int Contador { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}