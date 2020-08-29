using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodForm.Data;
using FoodForm.Models;
using Microsoft.AspNetCore.Authorization;

namespace FoodForm.Controllers
{
    [Authorize] //todos os métodos desta class ficaram protegidos em vez de ter de realizar a autorização individual de cada função.
    public class ReceitasController : Controller
    {
        private readonly FoodFormDB _context;

        public ReceitasController(FoodFormDB context)
        {
            _context = context;
        }

        // GET: Receitas
        [AllowAnonymous] //permite visualizar se o utilizador for anonimo -> anula o anotador [Authorize]
        public async Task<IActionResult> Index()
        {
            var foodFormDB = _context.Receitas.Include(r => r.Utilizador);
            return View(await foodFormDB.ToListAsync());
        }

        // GET: Receitas/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receitas = await _context.Receitas
                .Include(r => r.Utilizador)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (receitas == null)
            {
                return NotFound();
            }

            return View(receitas);
        }

        // GET: Receitas/Create
        // Faz o GET da Interface para apresentar
        public IActionResult Create()
        {
            ViewData["Autor"] = new SelectList(_context.Utilizadores, "ID", "ID");
            return View();
        }

        // POST: Receitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titulo,Descricao,Imagem,Dificuldade,Tempo,PessoasServidas,Ingredientes,Autor")] Receitas receitas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receitas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Autor"] = new SelectList(_context.Utilizadores, "ID", "ID", receitas.Autor);
            return View(receitas);
        }

        // GET: Receitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receitas = await _context.Receitas.FindAsync(id);
            if (receitas == null)
            {
                return NotFound();
            }
            ViewData["Autor"] = new SelectList(_context.Utilizadores, "ID", "ID", receitas.Autor);
            return View(receitas);
        }

        // POST: Receitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titulo,Descricao,Imagem,Dificuldade,Tempo,PessoasServidas,Ingredientes,Autor")] Receitas receitas)
        {
            if (id != receitas.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receitas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceitasExists(receitas.ID))
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
            ViewData["Autor"] = new SelectList(_context.Utilizadores, "ID", "ID", receitas.Autor);
            return View(receitas);
        }

        // GET: Receitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receitas = await _context.Receitas
                .Include(r => r.Utilizador)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (receitas == null)
            {
                return NotFound();
            }

            return View(receitas);
        }

        // POST: Receitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receitas = await _context.Receitas.FindAsync(id);
            _context.Receitas.Remove(receitas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceitasExists(int id)
        {
            return _context.Receitas.Any(e => e.ID == id);
        }
    }
}
