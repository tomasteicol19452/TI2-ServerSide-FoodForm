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
using Microsoft.AspNetCore.Identity;
using Xceed.Wpf.Toolkit;

namespace FoodForm.Controllers
{
    [Authorize]
    public class ComentariosController : Controller
    {
        private readonly FoodFormDB _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public ComentariosController(FoodFormDB context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Comentarios
        [Authorize(Roles ="Moderador")]
        public async Task<IActionResult> Index()
        {
            var foodFormDB = _context.Comentarios.Include(c => c.Receita).Include(c => c.Utilizador);
            return View(await foodFormDB.ToListAsync());
        }

        // GET: Comentarios/Details/5
        [Authorize(Roles = "Moderador")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentarios = await _context.Comentarios
                .Include(c => c.Receita)
                .Include(c => c.Utilizador)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (comentarios == null)
            {
                return NotFound();
            }

            return View(comentarios);
        }

        // GET: Comentarios/Create
        public IActionResult Create()
        {
            ViewData["ReceitaFK"] = new SelectList(_context.Receitas, "ID", "Descricao");
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "ID", "Email");
            return View();
        }

        // POST: Comentarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Conteudo")] Comentarios comentarios, int id)
        {
            if (ModelState.IsValid)
            {
                //Utilizador que está a comentar
                Utilizadores user = _context.Utilizadores
                    .Where(u => u.UserID == _userManager.GetUserId(User))
                    .FirstOrDefault();
                //Receita que está a ser comentada
                Receitas receita = _context.Receitas
                    .Where(r => r.ID == id)
                    .FirstOrDefault();

                if( user == null || receita == null)
                {
                    return NotFound();
                }

                //criação do comentario
                var comentario = new Comentarios
                {
                    Conteudo = comentarios.Conteudo,
                    Data = DateTime.Now,
                    UtilizadorFK = user.ID,
                    ReceitaFK = receita.ID
                };

                _context.Comentarios.Add(comentario);

                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "Receitas", new { Id = id });
            }
            return NotFound();
        }

        //// GET: Comentarios/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var comentarios = await _context.Comentarios.FindAsync(id);
        //    if (comentarios == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ReceitaFK"] = new SelectList(_context.Receitas, "ID", "Descricao", comentarios.ReceitaFK);
        //    ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "ID", "Email", comentarios.UtilizadorFK);
        //    return View(comentarios);
        //}

        //// POST: Comentarios/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Data,Conteudo,UtilizadorFK,ReceitaFK")] Comentarios comentarios)
        //{
        //    if (id != comentarios.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(comentarios);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ComentariosExists(comentarios.ID))
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
        //    ViewData["ReceitaFK"] = new SelectList(_context.Receitas, "ID", "Descricao", comentarios.ReceitaFK);
        //    ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "ID", "Email", comentarios.UtilizadorFK);
        //    return View(comentarios);
        //}

        // GET: Comentarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios
                .Include(c => c.Receita)
                .Include(c => c.Utilizador)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comentarios = await _context.Comentarios.FindAsync(id);
            _context.Comentarios.Remove(comentarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComentariosExists(int id)
        {
            return _context.Comentarios.Any(e => e.ID == id);
        }
    }
}
