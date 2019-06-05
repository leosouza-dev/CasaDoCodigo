using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class CarrinhoItem
    {
        public int Id { get; set; }
        public Livro Livro { get; set; }
        public int Quantidade { get; set; }
        public int CarrinhoCompraId { get; set; }
    }
}
