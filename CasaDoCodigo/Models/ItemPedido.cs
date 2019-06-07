namespace CasaDoCodigo.Models
{
    public class ItemPedido
    {
        public ItemPedido()
        {

        }
        public ItemPedido(Pedido pedido, Livro livro, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            Livro = livro;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }
        public int Id { get; set; }
        public Pedido Pedido { get; private set; }
        public Livro Livro { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
    }
}