namespace Nucleo.Entidades
{
    public class ClienteCarro
    {
        public ClienteCarro()
        {
        }

        public ClienteCarro(string idC)
        {
            id=idC;
        }

        public string id { get; set; }   
        public List<ItemCarro> items { get; set; } = new List<ItemCarro>();
    }
}