using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using FoodForm.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using FoodForm.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace FoodForm.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        /// <summary>
        /// Onde estão guardados os ficheiros
        /// </summary>
        private readonly IWebHostEnvironment _caminho;

        /// <summary>
        /// Contexto da base de dados
        /// </summary>
        private readonly FoodFormDB _context;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            FoodFormDB context,
            IWebHostEnvironment caminho)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
            _caminho = caminho;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "A {0} deve conter pelomenos {2} caracteres e no máximo {1}.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "A palavra pass e a sua confirmação não são iguais.")]
            public string ConfirmPassword { get; set; }

            //************** Utilizadores **********************
            public Utilizadores Utilizador { get; set; }
        }

        /// <summary>
        /// Chamado quando o HTTP request é GET
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        /// <summary>
        /// Chamado quando o HTTP request é POST enviando os dados do formulário para a base de dados
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(IFormFile fotoUser ,string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            //não são utilizados ferramentas externas para a criação do registo
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid) //refere-se ao Input Model (linha 41)
            {

                //adicionar o codigo para processar o ficheiro da imagem do user
                string caminhoCompleto = "";
                string nomeFoto = "";
                bool haImagem = false;

                if (fotoUser == null)
                {
                    nomeFoto = "no-user.jpg";
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
                        nomeFoto = nome;
                        //assinalar que existe imagem e é preciso guarda-la no disco
                        haImagem = true;
                    }
                    else
                    {
                        nomeFoto = "no-user.jpg";
                    }
                }

                var user = new ApplicationUser { 
                    UserName = Input.Email, 
                    Email = Input.Email,
                    Timestamp = DateTime.Now
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //associa o role "Utilzador" ao utilizador criado
                    await _userManager.AddToRoleAsync(user, "Utilizador");

                    //criar na base de dados um registo com o utilizador criado
                    Utilizadores novoUtilizador = Input.Utilizador;
                    //ligar este Utilizador a quem fez o Registo
                    novoUtilizador.UserID = user.Id;
                    novoUtilizador.Imagem = nomeFoto;


                    // adicionar estes dados e guardar na BD
                    // adiciona o novo Utilizador à BD, mas na memória do servidor ASP .NET
                    _context.Add(novoUtilizador);

                    // consolida os dados no Servidor BD (commit)
                    await _context.SaveChangesAsync();

                    // se há imagem, vou guardá-la no disco rígido
                    if (haImagem)
                    {
                        using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                        await fotoUser.CopyToAsync(stream);
                    }


                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
