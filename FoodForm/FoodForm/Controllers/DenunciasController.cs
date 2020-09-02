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
    [Authorize]
    public class DenunciasController : Controller
    {
        private readonly FoodFormDB _context;

        public DenunciasController(FoodFormDB context)
        {
            _context = context;
        }
        
        // GET: Denuncias
        [Authorize(Roles = "Moderador")]
        public async Task<IActionResult> Index()
        {
            var foodFormDB = _context.Denuncias.Include(d => d.Receita).Include(d => d.Utilizador);
            return View(await foodFormDB.ToListAsync());
        }

        // GET: Denuncias/Details/5
        [Authorize(Roles = "Moderador")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denuncias = await _context.Denuncias
                .Include(d => d.Receita)
                .Include(d => d.Utilizador)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (denuncias == null)
            {
                return NotFound();
            }

            return View(denuncias);
        }

        // GET: Denuncias/Create
        public IActionResult Create()
        {
            ViewData["ReceitaFK"] = new SelectList(_context.Receitas, "ID", "Descricao");
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "ID", "Email");
            return View();
        }

        // POST: Denuncias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Data,Conteudo,UtilizadorFK,ReceitaFK")] Denuncias denuncias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(denuncias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReceitaFK"] = new SelectList(_context.Receitas, "ID", "Descricao", denuncias.ReceitaFK);
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "ID", "Email", denuncias.UtilizadorFK);
            return View(denuncias);
        }

        //// GET: Denuncias/Edit/5
        //[Authorize(Roles = "Moderador")]
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var denuncias = await _context.Denuncias.FindAsync(id);
        //    if (denuncias == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ReceitaFK"] = new SelectList(_context.Receitas, "ID", "Descricao", denuncias.ReceitaFK);
        //    ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "ID", "Email", denuncias.UtilizadorFK);
        //    return View(denuncias);
        //}

        //// POST: Denuncias/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Moderador")]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Data,Conteudo,UtilizadorFK,ReceitaFK")] Denuncias denuncias)
        //{
        //    if (id != denuncias.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(denuncias);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DenunciasExists(denuncias.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ReceitaFK"] = new SelectList(_context.Receitas, "ID", "Descricao", denuncias.ReceitaFK);
        //    ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "ID", "Email", denuncias.UtilizadorFK);
        //    return View(denuncias);
        //}

        // GET: Denuncias/Delete/5
        [Authorize(Roles = "Moderador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denuncias = await _context.Denuncias
                .Include(d => d.Receita)
                .Include(d => d.Utilizador)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (denuncias == null)
            {
                return NotFound();
            }

            return View(denuncias);
        }

        // POST: Denuncias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Moderador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var denuncias = await _context.Denuncias.FindAsync(id);
            _context.Denuncias.Remove(denuncias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DenunciasExists(int id)
        {
            return _context.Denuncias.Any(e => e.ID == id);
        }
    }
}
