using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodForm.Data;
using FoodForm.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FoodForm.Controllers
{   
    [Authorize]
    public class UtilizadoresController : Controller
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

        public UtilizadoresController(FoodFormDB context, IWebHostEnvironment caminho, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _caminho = caminho;
            _userManager = userManager;
        }

        // GET: Utilizadores
        /// <summary>
        /// Invoca a View dos Utilizadores
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            //se o utilizador com Role = Moderador
            if (User.IsInRole("Moderador"))
            {
                //em sql utilizadores.ToListAsync é o mesmo que "SELECT * FROM utilizadores"
                return View(await _context.Utilizadores.ToListAsync());
            }

            // Senão vamos só mostrar os dados da pessoa que se autenticou
            Utilizadores utilizador = _context.Utilizadores
                                         .Where(u => u.UserID == _userManager.GetUserId(User))
                                         .FirstOrDefault();

            return RedirectToAction("Details", new { id = utilizador.ID });
        }

        // GET: Utilizadores/Details/5
        /// <summary>
        /// Mostra dos detalhes do um Utilizador
        /// </summary>
        /// <param name="id">Identificador do Utilizador a detalhar.</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                
                return RedirectToAction("Index", "Home");
            }

            /*
             Em SQL
             SELECT *
             FROM utilizadores u, receitas r, gostos g
             WHERE u.ID = id 
             AND r.Autor = u.ID
             AND g.UtilizadorFK = u.ID
             AND u.UserName = AspNetUsers.ID
             */
            
            var utilizadores = await _context.Utilizadores
                .Include(r => r.MinhasReceitas)
                .Where(u => u.ID == id)
                .FirstOrDefaultAsync();
            if (utilizadores == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(utilizadores);
        }

        // GET: Utilizadores/Create
        [Authorize(Roles = "Moderador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Moderador")]
        public async Task<IActionResult> Create([Bind("ID,Nome,Imagem")] Utilizadores utilizador, IFormFile fotoUser) //Alterações permitem receber um ficheiro no formato de IFormFile
        {
            //string que contem o caminho até a imagem
            string caminhoCompleto = "";
            bool haImagem = false;

            //porcessar a fotografia
            //será que há fotografia?->verificação de existencia de fotografia
            if(fotoUser == null) { 
                utilizador.Imagem = "no-user.jpg";
            }
            else
            {
                //especificação do content type
                if(fotoUser.ContentType == "image/jpeg" || fotoUser.ContentType == "image/png")
                {
                    //pepara o nome unico do ficheiro para guardar no disco rigido do servido
                    Guid g;
                    g = Guid.NewGuid();
                    string extensao = Path.GetExtension(fotoUser.FileName).ToLower();
                    string nome = g.ToString() + extensao;
                    //onde guardar o ficheiro / a sua diretoria
                    caminhoCompleto = Path.Combine(_caminho.WebRootPath, "img\\utilizadores", nome);
                    //assosciar o nome do ficheiro ao utilizador
                    utilizador.Imagem = nome;
                    //assinalar que existe imagem e é preciso guarda-la no disco
                    haImagem = true;
                }
                else
                {
                    utilizador.Imagem = "no-user.jpg";
                }
            }


            if (ModelState.IsValid)
            {
                try
                {
                    //adicionar os dados do utilizador
                    _context.Add(utilizador);
                    //guardar os dados desse utilizador
                    await _context.SaveChangesAsync();
                    //se ha imagem, guardar no disco rigido
                    if (haImagem)
                    {
                        using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                        await fotoUser.CopyToAsync(stream);
                    }
                    //devolver o controlo a view Index
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    // se chegar aqui, é pq alguma coisa correu mesmo mal...
                    // o que fazer?
                    // opções a realizar (todas, ou apenas uma...):
                    //   - escrever, no disco do servidor, um log com o erro
                    //   - escrever numa tabela de Erros, na BD, o log do erro
                    //   - enviar o modelo de volta para a View
                    //   - se o erro for corrigível, corrigir o erro
                }
            }
            return View(utilizador);
        }

        // GET: Utilizadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var utilizador = await _context.Utilizadores.FindAsync(id);
            if (utilizador == null)
            {
                return RedirectToAction("Index");
            }
            return View(utilizador);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Imagem")] Utilizadores utilizador, IFormFile fotoUser)
        {
            if (id != utilizador.ID)
            {
                return NotFound();
            }

            //string que contem o caminho até a imagem
            string caminhoCompleto = "";
            bool haImagem = false;

            //porcessar a fotografia
            //será que há fotografia?->verificação de existencia de fotografia
            if (fotoUser == null)
            {
                utilizador.Imagem = "no-user.jpg";
            }
            else
            {
                //especificação do content type
                if (fotoUser.ContentType == "image/jpeg" || fotoUser.ContentType == "image/png")
                {
                    //pepara o nome unico do ficheiro para guardar no disco rigido do servido
                    Guid g;
                    g = Guid.NewGuid();
                    string extensao = Path.GetExtension(fotoUser.FileName).ToLower();
                    string nome = g.ToString() + extensao;
                    //onde guardar o ficheiro / a sua diretoria
                    caminhoCompleto = Path.Combine(_caminho.WebRootPath, "img\\utilizadores", nome);
                    //assosciar o nome do ficheiro ao utilizador
                    utilizador.Imagem = nome;
                    //assinalar que existe imagem e é preciso guarda-la no disco
                    haImagem = true;
                }
                else
                {
                    utilizador.Imagem = "no-user.jpg";
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilizador);
                    await _context.SaveChangesAsync();

                    //se ha imagem, guardar no disco rigido
                    if (haImagem)
                    {
                        using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                        await fotoUser.CopyToAsync(stream);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizadoresExists(utilizador.ID))
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
            return View(utilizador);
        }

        // GET: Utilizadores/Delete/5
        [Authorize(Roles = "Moderador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var utilizador = await _context.Utilizadores
                .FirstOrDefaultAsync(m => m.ID == id);
            if (utilizador == null)
            {
                return RedirectToAction("Index");
            }

            return View(utilizador);
        }

        // POST: Utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Moderador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utilizador = await _context.Utilizadores.FindAsync(id);
            _context.Utilizadores.Remove(utilizador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilizadoresExists(int id)
        {
            return _context.Utilizadores.Any(e => e.ID == id);
        }
    }
}
