using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class LivroViewModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Preco { get; set; }
        public int NumeroPagina { get; set; }
        public string Isbn { get; set; }
        public int AutorId { get; set; }
        public int SubcategoriaId { get; set; }
    }
}
