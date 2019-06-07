using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        //checar isso
        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
    }
}
