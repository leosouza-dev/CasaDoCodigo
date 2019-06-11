using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class JsonResponse
    {
        [JsonProperty("item")]
        public Pedido pedido { get; set; }
        //public List<ItemPedido> Itens { get; set; }
        //public Livro Livro { get; set; }
    }
}
