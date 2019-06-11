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

        //cria pedido
        public void CriaPedido()
        {
            Random rnd = new Random();
            Id = rnd.Next();
        }

        //Adiciona Item
        public void AddItem(ItemPedido item)
        {
            Itens.Add(item);
        }

        //Serealizar pedido
        public string Serialize(Pedido pedido)
        {
            return JsonConvert.SerializeObject(pedido, Formatting.Indented,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

    }
}
