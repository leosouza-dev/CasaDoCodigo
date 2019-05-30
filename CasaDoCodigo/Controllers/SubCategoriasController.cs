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
    public class SubCategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubCategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubCategorias
        public async Task<IActionResult> Index()
        {
            //incluindo dados de categoria
            var applicationDbContext = _context.SubCategorias.Include(s => s.Categoria);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SubCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategoria = await _context.SubCategorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCategoria == null)
            {
                return NotFound();
            }

            return View(subCategoria);
        }

        // GET: SubCategorias/Create
        public IActionResult Create()
        {
            //var vm = new SubcategoriaViewModel();
            var vm = Instancia();
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Titulo");
            return View(vm);
        }

        public SubcategoriaViewModel Instancia()
        {
            return new SubcategoriaViewModel();
            
        }

        // POST: SubCategorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubcategoriaViewModel subCategoriaVM)
        { 


            if (ModelState.IsValid)
            {
                
                var subcategoria = new SubCategoria
                {
                    Titulo = subCategoriaVM.Titulo,
                    Categoria = _context.Categorias.FirstOrDefault(m => m.Id == subCategoriaVM.CategoriaId)
                };

                System.Diagnostics.Debug.WriteLine("Teste mano");
                Console.WriteLine("Teste");

                _context.Add(subcategoria);
                 //  _context.Entry(subcategoria.Categoria).State = EntityState.Unchanged;
                 await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //repopula o dropdown
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Titulo");
            return View(subCategoriaVM);
            //return Create();
        }

        // GET: SubCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategoria = await _context.SubCategorias.FindAsync(id);
            if (subCategoria == null)
            {
                return NotFound();
            }
            return View(subCategoria);

        }

        // POST: SubCategorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo")] SubCategoria subCategoria)
        {
            if (id != subCategoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubCategoriaExists(subCategoria.Id))
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
            return View(subCategoria);
        }

        // GET: SubCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategoria = await _context.SubCategorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCategoria == null)
            {
                return NotFound();
            }

            return View(subCategoria);
        }

        // POST: SubCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCategoria = await _context.SubCategorias.FindAsync(id);
            _context.SubCategorias.Remove(subCategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubCategoriaExists(int id)
        {
            return _context.SubCategorias.Any(e => e.Id == id);
        }
    }
}
