using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class CarrinhoViewModel
    {
        public Livro Livro { get; set; }
        public decimal TotalItem { get; set; }
        public decimal TotalCarrinho { get; set; }
    }
}
