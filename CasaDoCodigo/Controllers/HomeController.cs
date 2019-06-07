using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CasaDoCodigo.Models;
using CasaDoCodigo.Data;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var livros = _context.Livros.Include(s => s.Autor).Include(s => s.SubCategoria);
            return View(livros);
        }

    }
}
