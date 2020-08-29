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
    public class ModeradoresController : Controller
    {
        private readonly FoodFormDB _context;

        public ModeradoresController(FoodFormDB context)
        {
            _context = context;
        }

        // GET: Moderadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Moderadores.ToListAsync());
        }

        // GET: Moderadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moderadores = await _context.Moderadores
                .FirstOrDefaultAsync(m => m.ID == id);
            if (moderadores == null)
            {
                return NotFound();
            }

            return View(moderadores);
        }

        // GET: Moderadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moderadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Email")] Moderadores moderadores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moderadores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moderadores);
        }

        // GET: Moderadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moderadores = await _context.Moderadores.FindAsync(id);
            if (moderadores == null)
            {
                return NotFound();
            }
            return View(moderadores);
        }

        // POST: Moderadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Email")] Moderadores moderadores)
        {
            if (id != moderadores.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moderadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeradoresExists(moderadores.ID))
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
            return View(moderadores);
        }

        // GET: Moderadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moderadores = await _context.Moderadores
                .FirstOrDefaultAsync(m => m.ID == id);
            if (moderadores == null)
            {
                return NotFound();
            }

            return View(moderadores);
        }

        // POST: Moderadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moderadores = await _context.Moderadores.FindAsync(id);
            _context.Moderadores.Remove(moderadores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeradoresExists(int id)
        {
            return _context.Moderadores.Any(e => e.ID == id);
        }
    }
}
