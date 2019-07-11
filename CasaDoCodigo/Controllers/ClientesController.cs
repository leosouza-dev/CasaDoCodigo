using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CasaDoCodigo.Data;
using CasaDoCodigo.Models;
using AutoMapper;

namespace CasaDoCodigo.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClientesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Clientes
        public IActionResult Index()
        {
            return View();
        }


        // GET: Clientes/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteViewModel clienteVM)
        {
            if (ModelState.IsValid)
            {
                var cliente = _mapper.Map<Cliente>(clienteVM);
                var endereco = new Endereco()
                {
                    CEP = clienteVM.CEP,
                    Cidade = clienteVM.Cidade,
                    Complemento = clienteVM.Complemento,
                    Estado = clienteVM.Estado,
                    Numero = clienteVM.Numero,
                    Pais = clienteVM.Pais,
                    Rua = clienteVM.Rua
                };
                cliente.Endereco = endereco;

                _context.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteVM);
        }
    }
}
