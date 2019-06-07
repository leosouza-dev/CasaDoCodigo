using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.Data;
using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Carrinho _carrinho;
        public CarrinhoController(ApplicationDbContext context, Carrinho carrinho)
        {
            _context = context;
            _carrinho = carrinho;
        }

        public IActionResult Index()
        {
            var itens = _carrinho.GetCarrinhoItems();
            _carrinho.CarrinhoItens = itens;

            var carrinhoVM = new CarrinhoViewModel()
            {
                Carrinho = _carrinho,
                CarrinhoTotal = _carrinho.GetCarrinhoTotal()
            };

            return View(carrinhoVM);
        }

        public RedirectToActionResult AdicionarItemNoCarrinho(int livroId)
        {
            var livroSelecionado = _context.Livros.FirstOrDefault(p => p.Id == livroId);

            if(livroSelecionado != null)
            {
                _carrinho.AdicionarNoCarrinho(livroSelecionado, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoverItemDoCarrinho(int livroId)
        {
            var livroSelecionado = _context.Livros.FirstOrDefault(p => p.Id == livroId);

            if (livroSelecionado != null)
            {
                _carrinho.RemoverrDoCarrinho(livroSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}