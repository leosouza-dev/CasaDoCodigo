using CasaDoCodigo.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Models
{
    public class Carrinho
    {
        //essa classe trabalhará em memória

        //injeção de dep. do contexto
        private readonly ApplicationDbContext _context;
        public Carrinho(ApplicationDbContext context)
        {
            _context = context;
        }
        

        //props
        public string Id { get; set; }
        public IEnumerable<CarrinhoItem> CarrinhoItens{ get; set; }


        //Metodos
        //metodo para retornar um carrinho de compra - obtemos da session um carrinho
        public static Carrinho GetCarrinho(IServiceProvider services)
        {
            //define uma sessão acessando o contexto atual - tem que registar em IServiceCollection
            //operador condicional nulo - ? - se não tiver session, retorna nulo
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto
            var context = services.GetService<ApplicationDbContext>();

            //obtem ou gera o Id do Carrinho
            //operador de coalicencia nula - ?? - retorna o id do carrinho se existir, se naõ existir ele vai dar um new guid
            string id = session.GetString("Id") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na sessão
            session.SetString("Id", id);

            //retorna o carrinho com o contexto atual e o Id atribuido ou obtido
            return new Carrinho(context)
            {
                Id = id
            };
        }


        //metodo para adicionar um item ao carrinho
        public void AdicionarNoCarrinho(Livro livro, int quantidade)
        {
            var item = _context.CarrinhoItens.SingleOrDefault(l => l.Livro.Id == livro.Id && l.CarrinhoCompraId == Id);

            //verifica se o carrinho exist, se não existir cria um
            if (item == null)
            {
                item = new CarrinhoItem
                {
                    CarrinhoCompraId = Id, //checar
                    Livro = livro,
                    Quantidade = 1
                };
                _context.CarrinhoItens.Add(item);
            }
            else //se existe incrementa
            {
                item.Quantidade++;
            }
            _context.SaveChanges();
        }


        //metodo para Remover um item ao carrinho
        public int RemoverrDoCarrinho(Livro livro)
        {
            var item = _context.CarrinhoItens.SingleOrDefault(l => l.Livro.Id == livro.Id && l.CarrinhoCompraId == Id);

            var quantidadeLocal = 0;

            if (item != null)
            {
                if(item.Quantidade > 1)
                {
                    item.Quantidade--;
                    quantidadeLocal = item.Quantidade;
                }
                else 
                {
                    _context.CarrinhoItens.Remove(item);
                }
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }


        //metodo para retornar os itens de um carrinho
        public IEnumerable<CarrinhoItem> GetCarrinhoItems()
        {
            return CarrinhoItens ?? (CarrinhoItens = _context.CarrinhoItens.Where(c => c.CarrinhoCompraId == Id)
                .Include(s => s.Livro).ToList());
        }

        //Metodo para limpar carrinho
        public void LimparCarrinho()
        {
            var itens = _context.CarrinhoItens.Where(c => c.CarrinhoCompraId == Id);

            _context.CarrinhoItens.RemoveRange(itens);
            _context.SaveChanges();
        }

        //Metodo para calcular o total
        public decimal GetCarrinhoTotal()
        {
            var total = _context.CarrinhoItens.Where(c => c.CarrinhoCompraId == Id).Select(c => c.Livro.Preco * c.Quantidade).Sum();
            return total;
        }
    }
}
