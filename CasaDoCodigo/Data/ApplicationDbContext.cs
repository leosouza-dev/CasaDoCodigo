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
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
