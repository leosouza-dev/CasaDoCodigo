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

        public string Nome { get; private set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "Campo {0} precisa ter entre {2} e {1} caracteres ", MinimumLength = 2)]
        public string Sobrenome { get; private set; }

        public string Documento { get; private set; }

        public string Email { get; private set; }

        public string Telefone { get; private set; }

        public Endereco Endereco { get; set; }


    }
}
