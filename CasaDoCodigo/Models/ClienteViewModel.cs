using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {

        }
        public ClienteViewModel(Cliente cliente)
        {
            Id = cliente.Id;
            Nome = cliente.Nome;
            Sobrenome = cliente.Sobrenome;
            Documento = cliente.Documento;
            Email = cliente.Email;
            Telefone = cliente.Telefone;
            Rua = cliente.Endereco.Rua;
            Numero = cliente.Endereco.Numero;
            Complemento = cliente.Endereco.Complemento;
            Cidade = cliente.Endereco.Cidade;
            Pais = cliente.Endereco.Pais;
            Estado = cliente.Endereco.Estado;
            CEP = cliente.Endereco.CEP;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        //public Cliente Cliente { get; }
    }
}
