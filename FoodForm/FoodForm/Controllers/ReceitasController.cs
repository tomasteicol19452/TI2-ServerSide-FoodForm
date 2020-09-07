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
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace FoodForm.Controllers
{
    [Authorize] //todos os métodos desta class ficaram protegidos em vez de ter de realizar a autorização individual de cada função.
    public class ReceitasController : Controller
    {
        /// <summary>
        /// Variavel que identifica a BD do nosso projecto
        /// </summary>
        private readonly FoodFormDB _context;

        /// <summary>
        /// variave que contem os dados do 'ambiente' do servidor.
        /// Em particular, onde estão os ficheiros guardados no disco rigido do servidor.
        /// </summary>
        private readonly IWebHostEnvironment _caminho;

        /// <summary>
        /// Recolher os dados remetentes á ao utlizador autenticado para esta variável
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;

        public ReceitasController(FoodFormDB context, IWebHostEnvironment caminho, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _caminho = caminho;
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
            
            Utilizadores Dono = _context.Utilizadores
                                         .Where(u => u.UserID == _userManager.GetUserId(User))
                                         .FirstOrDefault();
            ViewBag.ID_Dono = Dono.ID;

            Gostos gostado = _context.Gostos
                .Where(u => u.UtilizadorFK == Dono.ID && u.ReceitaFK == id).FirstOrDefault();
            if(gostado == null)
            {
                ViewBag.Liked = false;
            } else
            {
                ViewBag.Liked = true;
            }

            var receitas = await _context.Receitas
                .Include(r => r.Utilizador)
                .Include(c => c.ListaDeComentarios)
                .Include(g => g.ListaDeGostos)
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
            Utilizadores Dono = _context.Utilizadores
                                         .Where(u => u.UserID == _userManager.GetUserId(User))
                                         .FirstOrDefault();
            ViewBag.Owner = Dono.ID;
            ViewData["Autor"] = new SelectList(_context.Utilizadores, "ID", "ID");
            return View();
        }

        // POST: Receitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titulo,Descricao,Imagem,Dificuldade,Tempo,PessoasServidas,Ingredientes,Autor")] Receitas receita, IFormFile fotoReceita)
        {
            //string que contem o caminho até a imagem
            string caminhoCompleto = "";
            bool haImagem = false;

            //porcessar a fotografia
            //será que há fotografia?->verificação de existencia de fotografia
            if (fotoReceita == null)
            {
                receita.Imagem = "no-food.jpg";
            }
            else
            {
                //especificação do content type
                if (fotoReceita.ContentType == "image/jpeg" || fotoReceita.ContentType == "image/png")
                {
                    //pepara o nome unico do ficheiro para guardar no disco rigido do servido
                    Guid g;
                    g = Guid.NewGuid();
                    string extensao = Path.GetExtension(fotoReceita.FileName).ToLower();
                    string nome = g.ToString() + extensao;
                    //onde guardar o ficheiro / a sua diretoria
                    caminhoCompleto = Path.Combine(_caminho.WebRootPath, "img\\receitas", nome);
                    //assosciar o nome do ficheiro á receita
                    receita.Imagem = nome;
                    //assinalar que existe imagem e é preciso guarda-la no disco
                    haImagem = true;
                }
                else
                {
                    receita.Imagem = "no-food.jpg";
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(receita);
                await _context.SaveChangesAsync();

                //se ha imagem, guardar no disco rigido
                if (haImagem)
                {
                    using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                    await fotoReceita.CopyToAsync(stream);
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["Autor"] = new SelectList(_context.Utilizadores, "ID", "ID", receita.Autor);
            return View(receita);
        }

        // GET: Receitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Utilizadores Dono = _context.Utilizadores
                                        .Where(u => u.UserID == _userManager.GetUserId(User))
                                        .FirstOrDefault();
            ViewBag.Owner = Dono.ID;

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
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titulo,Descricao,Imagem,Dificuldade,Tempo,PessoasServidas,Ingredientes,Autor")] Receitas receitas, IFormFile fotoReceita)
        {
            if (id != receitas.ID)
            {
                return NotFound();
            }

            //string que contem o caminho até a imagem
            string caminhoCompleto = "";
            bool haImagem = false;

            //porcessar a fotografia
            //será que há fotografia?->verificação de existencia de fotografia
            if (fotoReceita == null)
            {
                receitas.Imagem = "no-food.jpg";
            }
            else
            {
                //especificação do content type
                if (fotoReceita.ContentType == "image/jpeg" || fotoReceita.ContentType == "image/png")
                {
                    //pepara o nome unico do ficheiro para guardar no disco rigido do servido
                    Guid g;
                    g = Guid.NewGuid();
                    string extensao = Path.GetExtension(fotoReceita.FileName).ToLower();
                    string nome = g.ToString() + extensao;
                    //onde guardar o ficheiro / a sua diretoria
                    caminhoCompleto = Path.Combine(_caminho.WebRootPath, "img\\receitas", nome);
                    //assosciar o nome do ficheiro á receita
                    receitas.Imagem = nome;
                    //assinalar que existe imagem e é preciso guarda-la no disco
                    haImagem = true;
                }
                else
                {
                    receitas.Imagem = "no-food.jpg";
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receitas);
                    await _context.SaveChangesAsync();

                    //se ha imagem, guardar no disco rigido
                    if (haImagem)
                    {
                        using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                        await fotoReceita.CopyToAsync(stream);
                    }
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
