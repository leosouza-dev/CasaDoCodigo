using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace CasaDoCodigo.Models
{
    public class ItemPedido
    {
        public ItemPedido()
        {

        }
        public ItemPedido(Livro livro)
        {
            //Pedido = pedido;
            Livro = livro;
            Quantidade = 1;
            PrecoUnitario = livro.Preco;
            Id = livro.Id;
        }

        //Random rnd = new Random();

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

        private decimal _subTotal;
        //metodo só de leitura = não alterar 
        public decimal SubTotal()
        {
            _subTotal = Quantidade * PrecoUnitario;
            return _subTotal;
        }

        public void IncrementaItem()
        {
            Quantidade++;
            SubTotal();
        }

        public void Decrementa()
        {
                Quantidade--;
                SubTotal();
        }
    }
}