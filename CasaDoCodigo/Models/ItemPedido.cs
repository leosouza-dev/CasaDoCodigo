using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace CasaDoCodigo.Models
{
    public class ItemPedido
    {
        private object random;

        public ItemPedido()
        {

        }
        public ItemPedido(Pedido pedido, Livro livro, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            Livro = livro;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            Id = rnd.Next();
        }


        Random rnd = new Random();

        [JsonProperty("ItemId")]
        public int Id { get; set; }

        [JsonProperty("Pedido")]
        public Pedido Pedido { get; private set; }

        [JsonProperty("Livro")]
        public Livro Livro { get; private set; }

        [JsonProperty("Quantidade")]
        public int Quantidade { get; private set; }

        [JsonProperty("PrecoUnitario")]
        public decimal PrecoUnitario { get; private set; }

        public decimal _subTotal;
        public void SubTotal()
        {
            _subTotal = Quantidade * PrecoUnitario;
        }
    }
}