using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "Campo {0} precisa ter entre {2} e {1} caracteres ", MinimumLength = 2)]
        public string Sobrenome { get; set; }

        public string Documento { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public Endereco Endereco { get; set; }


    }
}
