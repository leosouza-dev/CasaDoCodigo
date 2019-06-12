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
            Itens.Add(item);
        }

        public string Serialize(Pedido pedido)
        {
            return JsonConvert.SerializeObject(pedido, Formatting.Indented,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        //public decimal SubTotal(ItemPedido item)
        //{
        //    return item.Quantidade * item.PrecoUnitario;
        //}

        decimal precoTotal;
        public decimal PrecoTotal()
        {
            foreach (var item in Itens)
            {
                precoTotal += item._subTotal;
            }
            return precoTotal;
        }

        public int TotalItem()
        {
            return Itens.Count();
        }
    }
}
