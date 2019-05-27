using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class SubcategoriaViewModel
    {
        public SubCategoria SubCategoria { get; set; }
        public ICollection<Categoria> Categorias { get; set; }
    }
}
