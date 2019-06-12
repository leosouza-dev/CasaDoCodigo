using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class Pedido
    {
        public Pedido()
        {
            Itens = new List<ItemPedido>();
        }
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("Itens")]
        public List<ItemPedido> Itens { get; set; }

        //**************** métodos ****************
        public void CriaPedido()
        {
            Random rnd = new Random();
            Id = rnd.Next();
        }

        public void AddItem(ItemPedido item)
        {
            var livroExistente = Itens.Find(i => i.Livro.Titulo == item.Livro.Titulo);

            if (!(livroExistente == null))
            {
                item = livroExistente;
                item.IncrementaItem();
            }
            else
            {
                Itens.Add(item);
                item.SubTotal();
            }
        }

        public string Serialize(Pedido pedido)
        {
            return JsonConvert.SerializeObject(pedido, Formatting.Indented,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        private decimal precoTotal;
        public decimal PrecoTotal()
        {
            foreach (var item in Itens)
            {
                precoTotal += item.SubTotal();
            }
            return precoTotal;
        }

        public int TotalItem()
        {
            return Itens.Count();
        }
    }
}
