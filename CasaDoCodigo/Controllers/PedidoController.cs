using CasaDoCodigo.Data;
using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        //metodos...
        public IActionResult Carrinho(int id)
        {
            if (id > 0)
            {
                _context.AddItem(id);
            }

            Pedido pedido = _context.GetPedido();
            return View(pedido.Itens);
        }



    }
}