using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class CategoriaViewModel
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "Campo {0} precisa ter entre {2} e {1} caracteres ", MinimumLength = 2)]
        public string Titulo { get; set; }
    }
}
