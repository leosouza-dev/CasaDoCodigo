namespace CasaDoCodigo.Models
{
    public class ItemPedido
    {
        public Pedido Pedido { get; private set; }
        public Livro Livro { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
    }
}