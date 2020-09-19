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

namespace FoodForm.Controllers
{
    [Authorize]
    public class GostosController : Controller
    {
        private readonly FoodFormDB _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public GostosController(FoodFormDB context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        // POST: Gostos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Utilizador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id)
        {
            //Utilizador que está a gostar
            Utilizadores user = _context.Utilizadores
                .Where(u => u.UserID == _userManager.GetUserId(User))
                .FirstOrDefault();
            //Receita que está a ser gostado
            Receitas receita = _context.Receitas
                .Where(r => r.ID == id)
                .FirstOrDefault();

            if(user == null || receita == null){
                return NotFound();
            }
            else
            {
                //criar o gosto
                var gosto = new Gostos
                {
                    ReceitaFK = receita.ID,
                    UtilizadorFK = user.ID,
                    Gosto = true
                };

                _context.Gostos.Add(gosto);
                await _context.SaveChangesAsync();
                //Redireciona para página da receita
                return RedirectToAction("Details", "Receitas", new { Id = id });
            }
        }

        // POST: Gostos/Delete/5
        [Authorize(Roles = "Utilizador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //Utilizador que está a gostar
            Utilizadores user = _context.Utilizadores
                .Where(u => u.UserID == _userManager.GetUserId(User))
                .FirstOrDefault();
            //Receita que está a ser gostada
            Receitas receita = _context.Receitas
                .Where(r => r.ID == id)
                .FirstOrDefault();
            //Gosto a ser apagado
            Gostos gosto = _context.Gostos.Where(g => g.ReceitaFK == receita.ID && g.UtilizadorFK == user.ID).FirstOrDefault();

            _context.Gostos.Remove(gosto);
            await _context.SaveChangesAsync();
            //Redireciona para a página da receita
            return RedirectToAction("Details","Receitas",new {Id = id});
        }

        private bool GostosExists(int id)
        {
            return _context.Gostos.Any(e => e.ID == id);
        }
    }
}
