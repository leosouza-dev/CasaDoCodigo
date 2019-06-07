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
            var livro = Livros
                .Where(p => p.Id == id)
                .SingleOrDefault();

            if (livro == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            var pedido = GetPedido();

            var itemPedido = ItensPedido.Where(i => i.Livro.Id == id&& i.Pedido.Id == pedido.Id).SingleOrDefault();

            if (itemPedido == null)
            {
                //checar em colocar um construtor com argumentos
                itemPedido = new ItemPedido(pedido, livro, 1, livro.Preco);
                ItensPedido.Add(itemPedido);

                SaveChanges();
            }
        }

        internal Pedido GetPedido()
        {
            var pedidoId = GetPedidoId();
            var pedido = Pedidos.Include(p => p.Itens).ThenInclude(i => i.Livro).Where(p => p.Id == pedidoId).SingleOrDefault();


            if (pedido == null)
            {
                pedido = new Pedido();
                Pedidos.Add(pedido);
                SaveChanges();
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
