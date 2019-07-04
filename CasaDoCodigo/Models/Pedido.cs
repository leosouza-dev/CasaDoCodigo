using CasaDoCodigo.Data;
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
        private readonly ApplicationDbContext _context;

        public Pedido(ApplicationDbContext context)
        {
            _context = context;
        }

        public Pedido()
        {
            Itens = new List<ItemPedido>();

        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("Itens")]
        public List<ItemPedido> Itens { get; set; }

        //**Metodos
        public void AddItem(Livro livro)
        {
            //buscar usando Equals???
            var itemExistente = Itens.Find(i => i.Livro.Equals(livro));

            if (itemExistente == null)
            {
                var item = new ItemPedido(livro);
                Itens.Add(item);
            }
            else
            {
                itemExistente.IncrementaItem();
            }
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented,
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

        public void DecrementaItem(Livro livro)
        {
            var item = Itens.Find(i => i.Livro.Equals(livro));

            if (item.Quantidade == 1)
            {
                Itens.Remove(item);
            }
            else
            {
                item.Decrementa();
            }
        }

    }
}
