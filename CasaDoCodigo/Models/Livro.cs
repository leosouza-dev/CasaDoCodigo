using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Models
{
    public class Livro 
    {

        //chave primaria
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "Campo {0} precisa ter entre {2} e {1} caracteres ", MinimumLength = 2)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "Campo {0} precisa ter entre {2} e {1} caracteres ", MinimumLength = 2)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Imagem { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public int NumeroPagina { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Isbn { get; set; }

        public Autor Autor { get; set; }
        public SubCategoria SubCategoria { get; set; }
    }
}