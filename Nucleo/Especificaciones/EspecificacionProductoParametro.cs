namespace Nucleo.Especificaciones
{
    public class EspecificacionProductoParametro
    {
        private const int MaxPageSize = 50;
        public int PageIndex {get; set;} = 1;
        public int _pageSize { get; set; } = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize)? MaxPageSize: value;
        }
        public int? MarcaId { get; set; }
        public int? TipoId { get; set; }
        public string? Orden { get; set; }
        private string _buscar;
        public string? Buscar
        {
            get => _buscar;
            set=> _buscar = value.ToLower();
        }
    }
}