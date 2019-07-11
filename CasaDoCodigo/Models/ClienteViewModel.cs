using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class ClienteViewModel
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Documento { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
    }
}
