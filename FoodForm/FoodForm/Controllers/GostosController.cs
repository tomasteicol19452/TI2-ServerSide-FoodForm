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
    public class GostosController : Controller
    {
        private readonly FoodFormDB _context;

        public GostosController(FoodFormDB context)
        {
            _context = context;
        }

        // GET: Gostos
        [Authorize(Roles = "Moderador")]
        public async Task<IActionResult> Index()
        {
            var foodFormDB = _context.Gostos.Include(g => g.Receita).Include(g => g.Utilizador);
            return View(await foodFormDB.ToListAsync());
        }

        // GET: Gostos/Details/5
        [Authorize(Roles = "Moderador")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gostos = await _context.Gostos
                .Include(g => g.Receita)
                .Include(g => g.Utilizador)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gostos == null)
            {
                return NotFound();
            }

            return View(gostos);
        }

        // GET: Gostos/Create
        public IActionResult Create()
        {
            ViewData["ReceitaFK"] = new SelectList(_context.Receitas, "ID", "Descricao");
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "ID", "Email");
            return View();
        }

        // POST: Gostos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Gosto,UtilizadorFK,ReceitaFK")] Gostos gostos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gostos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReceitaFK"] = new SelectList(_context.Receitas, "ID", "Descricao", gostos.ReceitaFK);
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "ID", "Email", gostos.UtilizadorFK);
            return View(gostos);
        }

        //// GET: Gostos/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var gostos = await _context.Gostos.FindAsync(id);
        //    if (gostos == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ReceitaFK"] = new SelectList(_context.Receitas, "ID", "Descricao", gostos.ReceitaFK);
        //    ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "ID", "Email", gostos.UtilizadorFK);
        //    return View(gostos);
        //}

        //// POST: Gostos/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Gosto,UtilizadorFK,ReceitaFK")] Gostos gostos)
        //{
        //    if (id != gostos.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(gostos);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!GostosExists(gostos.ID))
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
        //    ViewData["ReceitaFK"] = new SelectList(_context.Receitas, "ID", "Descricao", gostos.ReceitaFK);
        //    ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "ID", "Email", gostos.UtilizadorFK);
        //    return View(gostos);
        //}

        // GET: Gostos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gostos = await _context.Gostos
                .Include(g => g.Receita)
                .Include(g => g.Utilizador)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gostos == null)
            {
                return NotFound();
            }

            return View(gostos);
        }

        // POST: Gostos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gostos = await _context.Gostos.FindAsync(id);
            _context.Gostos.Remove(gostos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GostosExists(int id)
        {
            return _context.Gostos.Any(e => e.ID == id);
        }
    }
}
