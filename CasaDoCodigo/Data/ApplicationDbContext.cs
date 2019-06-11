using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        private readonly IHttpContextAccessor _contextAccessor;


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor contextAccessor)
            : base(options)
        {
            _contextAccessor = contextAccessor;
        }



        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }


        internal void AddItem(int id)
        {
            //encontra o livro no banco de acordo com o Id;
            var livro = Livros.Where(p => p.Id == id).SingleOrDefault();
            //se livro não for encontrado, lança excption;
            if (livro == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            //busca ou gera um pedido novo
            var pedido = GetPedido();

            //busca um itemPedido de acordo com o Id pasaado de acordo com o Id do Livro e do Pedido
            var itemPedido = ItensPedido.Where(i => i.Livro.Id == id && i.Pedido.Id == pedido.Id).SingleOrDefault();

            //se o item do pedido for nulo
            if (itemPedido == null)
            {
                //cria um novo Itemedido e salva
                itemPedido = new ItemPedido(pedido, livro, 1, livro.Preco);
                ItensPedido.Add(itemPedido);

                SaveChanges();
            }
        }

        internal Pedido GetPedido()
        {
            //pega o PedidoId da session
            var pedidoId = GetPedidoId();
            //tenta encontrar um pedido no banco que seja o mesmo da session
            var pedido = Pedidos.Include(p => p.Itens).ThenInclude(i => i.Livro).Where(p => p.Id == pedidoId).SingleOrDefault();

            //caso não exista o pedido no banco
            if (pedido == null)
            {
                //cria pedido novo
                pedido = new Pedido();
                //adiciona o pedido no banco
                Pedidos.Add(pedido);
                SaveChanges();
                //seta o pedido na session
                SetPedidoId(pedido.Id);
            }

            return pedido;
        }





        //session...
        private int? GetPedidoId()
        {
            return _contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        //grava o pedidoId na session
        private void SetPedidoId(int pedidoId)
        {
            _contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }
    }
}
