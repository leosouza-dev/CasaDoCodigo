using CasaDoCodigo.Data;
using CasaDoCodigo.Factory;
using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ApplicationDbContext _context;

        public PedidoController(IHttpContextAccessor contextAccessor, ApplicationDbContext context)
        {
            _contextAccessor = contextAccessor;
            _context = context;
        }


        public IActionResult Carrinho(int id)
        {
            //Usando Factory - Ver como torna-la statica
            PedidoFactory pedidoFactory = new PedidoFactory(_contextAccessor);
            var pedido = pedidoFactory.Criar();

            var livro = _context.Livros.Where(l => l.Id == id).FirstOrDefault();

            //add item
            pedido.AddItem(livro);

            //Serializa para JSON para ser passado para a Session
            var JsonPedido = pedido.Serialize();

            //Passado o JSON para session
            _contextAccessor.HttpContext.Session.SetString("pedido", JsonPedido);

            ViewData["Pedido"] = pedido;
            return View();
        }

        //Ajustar esse decremento.
        //muito codigo repetido.
        public IActionResult Decrementa(int id)
        {
            PedidoFactory pedidoFactory = new PedidoFactory(_contextAccessor);
            var pedido = pedidoFactory.Criar();

            var livro = _context.Livros.Where(l => l.Id == id).FirstOrDefault();

            pedido.DecrementaItem(livro);

            //Serializa para JSON para ser passado para a Session
            var JsonPedido = pedido.Serialize();

            //Passado o JSON para session
            _contextAccessor.HttpContext.Session.SetString("pedido", JsonPedido);

            ViewData["Pedido"] = pedido;

            return View("Carrinho");
        }
    }
}