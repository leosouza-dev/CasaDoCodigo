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

        public IActionResult Index()
        {
            return View();
        }

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

                _context.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction("Pagamento", new { id = cliente.Id }); //checar por que tem que dar um "new" (sem ele estava chagando zerado na action)
            }
            return View(clienteVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.Include(c => c.Endereco).FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            var clienteVM = _mapper.Map<ClienteViewModel>(cliente);

            //var clienteVM = new ClienteViewModel(cliente);

            return View(clienteVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClienteViewModel clienteVM)
        {
            if (id != clienteVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var cliente = _mapper.Map<Cliente>(clienteVM);
                _context.Update(cliente);
                await _context.SaveChangesAsync();

                return RedirectToAction("Pagamento", new { id = cliente.Id });
            }
            return View(clienteVM);
        }

        public IActionResult Pagamento(int id)
        {
            var cliente = _context.Clientes.Include(c => c.Endereco).FirstOrDefault(c => c.Id == id);
            cliente.Endereco.EndCompleto(); //pensar em usar o tostring
            return View(cliente);
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
