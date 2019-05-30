using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CasaDoCodigo.Data;
using CasaDoCodigo.Models;

namespace CasaDoCodigo.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LivrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Livroes
        public async Task<IActionResult> Index()
        {
            //incluindo dados de categoria
            var applicationDbContext = _context.Livros.Include(s => s.Autor).Include(s=>s.SubCategoria);
            return View(await applicationDbContext.ToListAsync());

            //return View(await _context.Livros.ToListAsync());
        }

        // GET: Livroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros.Include(s => s.Autor).Include(s => s.SubCategoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livroes/Create
        public IActionResult Create()
        {
            var vm = new LivroViewModel();

            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Nome");
            ViewData["SubcategoriaId"] = new SelectList(_context.SubCategorias, "Id", "Titulo");
            return View(vm);
        }

        // POST: Livroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LivroViewModel livroVM)
        {


            if (ModelState.IsValid)
            {


                var livro = new Livro
                {
                    Titulo = livroVM.Titulo,
                    Descricao = livroVM.Descricao,
                    Imagem = livroVM.Imagem,
                    Preco = livroVM.Preco,
                    NumeroPagina = livroVM.NumeroPagina,
                    Isbn = livroVM.Isbn,
                    Autor = _context.Autores.FirstOrDefault(a => a.Id == livroVM.AutorId),
                    SubCategoria = _context.SubCategorias.FirstOrDefault(s => s.Id == livroVM.SubcategoriaId)

                };

                _context.Add(livro);
                //_context.Entry(livro.Autor).State = EntityState.Unchanged;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Create();
        }

        // GET: Livroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        // POST: Livroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,Imagem,Preco,NumeroPagina,Isbn")] Livro livro)
        {
            if (id != livro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(livro);
        }

        // GET: Livroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
            return _context.Livros.Any(e => e.Id == id);
        }
    }
}
