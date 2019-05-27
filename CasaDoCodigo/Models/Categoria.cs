using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Models
{
    public class Categoria 
    {
        //chave primaria
        public int Id { get; set; }


        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "Campo {0} precisa ter entre {2} e {1} caracteres ", MinimumLength = 2)]
        public string Titulo { get; set; }

        public IEnumerable<Livro> Livros { get; set; }
        public IEnumerable<SubCategoria> SubCategorias { get; set; }
    }
}