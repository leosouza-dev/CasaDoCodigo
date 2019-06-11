﻿using CasaDoCodigo.Data;
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

        //metodos...
        public IActionResult Carrinho(int id)
        {
            //checa se pedido já existe na session
            var pedidoSession = _contextAccessor.HttpContext.Session.GetString("pedido");

            Pedido pedido;

            //se não existe...
            if (string.IsNullOrWhiteSpace(pedidoSession))
            {
                //novo pedido - mudar para injeção de dependencia
                pedido = new Pedido();
                //pedido.Itens = new List<ItemPedido>();
                pedido.CriaPedido();
            }
            else
            {
                pedido = JsonConvert.DeserializeObject<Pedido>(pedidoSession);
            }

            //temos que passar os dados do livro para o itemPedido
            var livro = _context.Livros.Where(l => l.Id == id).FirstOrDefault();
            //Cria um novo item com os dados do livro
            var item = new ItemPedido(pedido, livro, 1, livro.Preco);

            //add item
            pedido.AddItem(item);


            //Serializa para JSON para ser passado para a Session
            var JsonPedido = pedido.Serialize(pedido);

            //Passado o JSON para session
            _contextAccessor.HttpContext.Session.SetString("pedido", JsonPedido);
            return View(pedido.Itens);
        }
    }
}